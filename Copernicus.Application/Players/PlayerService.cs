using System;
using System.Linq;
using System.Threading.Tasks;
using Copernicus.Core.Domain.Games;
using Copernicus.Core.Domain.Players;
using Copernicus.Core.Repositories;

namespace Copernicus.Application.Players
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task CreatePlayer(Guid userId, string userName)
        {
            await _playerRepository.Create(new Player(Guid.NewGuid(), userId, userName));
        }

        public async Task UpdateStatsByLeaderboard(Leaderboard leaderboard)
        {
            foreach (var winner in leaderboard.Winners.Select((value, index) => new { index, value }))
            {
                var player = await _playerRepository.FindOne(winner.value.UserId);

                if (winner.index == 0)
                {
                    player.IncrementWinGames();
                }

                if (winner.index <= 10)
                {
                    player.AddScore(winner.value.Score);
                }

                player.IncrementTotalGames();

                await _playerRepository.Update(player);
            }
        }
    }
}