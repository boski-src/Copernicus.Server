using System.Threading.Tasks;
using Copernicus.Application.Games.Commands;
using Copernicus.Application.Games.Events;
using Copernicus.Common.CQRS.Commands;
using Copernicus.Common.CQRS.Notifications;

namespace Copernicus.Application.Games.Handlers
{
    public class ChangeQuestionHandler : ICommandHandler<ChangeQuestion>
    {
        private readonly IGameService _gameService;
        private readonly INotificationBus _notificationBus;

        public ChangeQuestionHandler(IGameService gameService, INotificationBus notificationBus)
        {
            _gameService = gameService;
            _notificationBus = notificationBus;
        }

        public async Task Handle(ChangeQuestion command)
        {
            var nextQuestion = await _gameService.NextQuestion(command.GameId, command.UserId);

            await _notificationBus.Publish(new QuestionChanged(command.GameId, nextQuestion));
        }
    }
}