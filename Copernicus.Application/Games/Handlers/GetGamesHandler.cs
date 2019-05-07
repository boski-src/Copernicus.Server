using System.Threading.Tasks;
using Copernicus.Application.Games.Queries;
using Copernicus.Common.CQRS.Queries;
using Copernicus.Common.Types;
using Copernicus.Core.Domain.Games;
using Copernicus.Core.Repositories;

namespace Copernicus.Application.Games.Handlers
{
    public class GetGamesHandler : IQueryHandler<GetGames, PagedList<Game>>
    {
        private readonly IGameRepository _gameRepository;

        public GetGamesHandler(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<PagedList<Game>> Handle(GetGames query)
        {
            return await _gameRepository.FindManyWaiting(query);
        }
    }
}