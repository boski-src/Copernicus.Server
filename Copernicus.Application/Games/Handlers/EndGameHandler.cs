using System.Threading.Tasks;
using Copernicus.Application.Games.Commands;
using Copernicus.Application.Games.Events;
using Copernicus.Common.CQRS.Commands;
using Copernicus.Common.CQRS.Events;
using Copernicus.Common.CQRS.Notifications;
using Copernicus.Common.TaskExecutor;

namespace Copernicus.Application.Games.Handlers
{
    public class EndGameHandler : ICommandHandler<EndGame>
    {
        private readonly IGameService _gameService;
        private readonly IEventBus _bus;
        private readonly INotificationBus _notificationBus;

        public EndGameHandler(IGameService gameService, IEventBus bus, INotificationBus notificationBus)
        {
            _gameService = gameService;
            _bus = bus;
            _notificationBus = notificationBus;
        }

        public async Task Handle(EndGame command)
        {
            await _gameService.End(command.GameId, command.UserId);
            
            await _notificationBus.Publish(new GameEnded(command.GameId));
            await _bus.Publish(new GameEnded(command.GameId));
        }
    }
}