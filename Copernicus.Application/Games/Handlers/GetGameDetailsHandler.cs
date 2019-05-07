using System.Threading.Tasks;
using Copernicus.Application.Games.Queries;
using Copernicus.Common.CQRS.Queries;
using Copernicus.Core.Domain.Games;
using Copernicus.Core.Repositories;

namespace Copernicus.Application.Games.Handlers
{
    public class GetGameDetailsHandler : IQueryHandler<GetGameDetails, Game>
    {
        private readonly IGameRepository _gameRepository;

        public GetGameDetailsHandler(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<Game> Handle(GetGameDetails query)
        {
            return await _gameRepository.FindOne(query.Id);
        }
    }
}