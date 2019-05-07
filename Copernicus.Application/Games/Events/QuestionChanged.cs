using System;
using Copernicus.Common.CQRS.Events;
using Copernicus.Common.CQRS.Notifications;

namespace Copernicus.Application.Games.Events
{
    public class QuestionChanged : IGameNotification
    {
        public Guid GameId { get; set; }
        public Guid QuestionId { get; set; }

        public QuestionChanged(Guid gameId, Guid questionId)
        {
            GameId = gameId;
            QuestionId = questionId;
        }
    }
}