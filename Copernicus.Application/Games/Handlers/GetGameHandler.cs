using System;
using System.Threading.Tasks;
using Copernicus.Application.Games.Queries;
using Copernicus.Common.CQRS.Queries;
using Copernicus.Core.Domain.Games;
using Copernicus.Core.Repositories;

namespace Copernicus.Application.Games.Handlers
{
    public class GetGameHandler : IQueryHandler<GetGame, Game>
    {
        private readonly IGameRepository _gameRepository;

        public GetGameHandler(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<Game> Handle(GetGame query)
        {
            var game = await _gameRepository.FindOne(query.Id);
            
            if (game != null && !game.IsMember(query.UserId))
            {
                throw new GameServiceExceptions.NotMember();
            }

            return game;
        }
    }
}
