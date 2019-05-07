using System.Threading.Tasks;
using Copernicus.Application.Games.Commands;
using Copernicus.Application.Games.Events;
using Copernicus.Common.CQRS.Commands;
using Copernicus.Common.CQRS.Events;
using Copernicus.Common.CQRS.Notifications;
using Copernicus.Common.TaskExecutor;
using Copernicus.Core.Domain.Games;

namespace Copernicus.Application.Games.Handlers
{
    public class CreateAnswerHandler : ICommandHandler<CreateAnswer>
    {
        private readonly IGameService _gameService;
        private readonly INotificationBus _notificationBus;

        public CreateAnswerHandler(IGameService gameService, INotificationBus notificationBus)
        {
            _gameService = gameService;
            _notificationBus = notificationBus;
        }

        public async Task Handle(CreateAnswer command)
        {
            var answer = await _gameService.CreateAnswer(
                command.GameId,
                command.QuestionId,
                command.UserId,
                command.Answer
            );

            await _notificationBus.Publish(new AnswerCreated(command.GameId, answer));
        }
    }
}