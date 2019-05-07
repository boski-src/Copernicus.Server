using System.Threading.Tasks;
using Copernicus.Application.Games.Commands;
using Copernicus.Common.CQRS.Commands;

namespace Copernicus.Application.Games.Handlers
{
    public class CreateGameHandler : ICommandHandler<CreateGame>
    {
        private readonly IGameService _gameService;

        public CreateGameHandler(IGameService gameService)
        {
            _gameService = gameService;
        }

        public async Task Handle(CreateGame command)
        {
            await _gameService.Create(command.Id, command.UserId, command.Name, command.PrimaryLanguage, command.MaxQuestions);
        }
    }
}