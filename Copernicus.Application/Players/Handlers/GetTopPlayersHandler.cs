using System.Collections.Generic;
using System.Threading.Tasks;
using Copernicus.Application.Players.Queries;
using Copernicus.Common.CQRS.Queries;
using Copernicus.Core.Domain.Players;
using Copernicus.Core.Repositories;

namespace Copernicus.Application.Players.Handlers
{
    public class GetTopPlayersHandler : IQueryHandler<GetTopPlayers, List<Player>>
    {
        private readonly IPlayerRepository _playerRepository;

        public GetTopPlayersHandler(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<List<Player>> Handle(GetTopPlayers query)
        {
            return await _playerRepository.FindManyAndSortByScore(20);
        }
    }
}