using System.Threading.Tasks;
using Copernicus.Application.Games.Events;
using Copernicus.Common.CQRS.Events;
using Copernicus.Core.Repositories;

namespace Copernicus.Application.Players.Handlers
{
    public class LeaderboardCalculatedHandler : IEventHandler<LeaderboardCalculated>
    {
        private readonly IPlayerService _playerService;
        private readonly IGameRepository _gameRepository;

        public LeaderboardCalculatedHandler(IPlayerService playerService, IGameRepository gameRepository)
        {
            _playerService = playerService;
            _gameRepository = gameRepository;
        }

        public async Task Handle(LeaderboardCalculated @event)
        {
            var game = await _gameRepository.FindOne(@event.GameId);
            await _playerService.UpdateStatsByLeaderboard(game.Leaderboard);
        }
    }
}