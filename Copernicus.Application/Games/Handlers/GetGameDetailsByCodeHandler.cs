using System.Threading.Tasks;
using Copernicus.Application.Games.Queries;
using Copernicus.Common.CQRS.Queries;
using Copernicus.Core.Domain.Games;
using Copernicus.Core.Repositories;

namespace Copernicus.Application.Games.Handlers
{
    public class GetGameDetailsByCodeHandler : IQueryHandler<GetGameDetailsByCode, Game>
    {
        private readonly IGameRepository _gameRepository;

        public GetGameDetailsByCodeHandler(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<Game> Handle(GetGameDetailsByCode query)
        {
            return await _gameRepository.FindOneByCode(query.Code);
        }
    }
}