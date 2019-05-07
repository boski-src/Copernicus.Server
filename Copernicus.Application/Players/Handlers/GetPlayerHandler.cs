using System.Threading.Tasks;
using Copernicus.Application.Players.Queries;
using Copernicus.Common.CQRS.Queries;
using Copernicus.Core.Domain.Players;
using Copernicus.Core.Repositories;

namespace Copernicus.Application.Players.Handlers
{
    public class GetPlayerHandler : IQueryHandler<GetPlayer, Player>
    {
        private readonly IPlayerRepository _playerRepository;

        public GetPlayerHandler(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<Player> Handle(GetPlayer query)
        {
            return await _playerRepository.FindOne(query.UserId);
        }
    }
}