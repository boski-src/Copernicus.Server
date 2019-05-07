using System.Threading.Tasks;
using Copernicus.Application.Games.Commands;
using Copernicus.Application.Games.Events;
using Copernicus.Common.CQRS.Commands;
using Copernicus.Common.CQRS.Events;
using Copernicus.Common.CQRS.Notifications;
using Copernicus.Common.TaskExecutor;
using Copernicus.Core.Repositories;

namespace Copernicus.Application.Games.Handlers
{
    public class JoinToGameHandler : ICommandHandler<JoinToGame>
    {
        private readonly IGameService _gameService;
        private readonly INotificationBus _notificationBus;
        private readonly IUserRepository _userRepository;

        public JoinToGameHandler(IGameService gameService, IUserRepository userRepository, INotificationBus notificationBus)
        {
            _gameService = gameService;
            _userRepository = userRepository;
            _notificationBus = notificationBus;
        }

        public async Task Handle(JoinToGame command)
        {
            await _gameService.Join(command.GameId, command.UserId);

            var user = await _userRepository.FindOne(command.UserId);
            await _notificationBus.Publish(new MemberJoined(command.GameId, command.UserId, user.Name, user.AvatarUrl));
        }
    }
}
