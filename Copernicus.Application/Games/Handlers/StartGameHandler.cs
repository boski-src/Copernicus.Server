using System.Threading.Tasks;
using Copernicus.Application.Games.Commands;
using Copernicus.Application.Games.Events;
using Copernicus.Common.CQRS.Commands;
using Copernicus.Common.CQRS.Events;
using Copernicus.Common.CQRS.Notifications;

namespace Copernicus.Application.Games.Handlers
{
    public class StartGameHandler : ICommandHandler<StartGame>
    {
        private readonly IGameService _gameService;
        private readonly INotificationBus _notificationBus;

        public StartGameHandler(IGameService gameService, INotificationBus bus)
        {
            _gameService = gameService;
            _notificationBus = bus;
        }

        public async Task Handle(StartGame command)
        {
            await _gameService.Start(command.GameId, command.UserId);
            await _notificationBus.Publish(new GameStarted(command.GameId));
        }
    }
}