using System;
using Copernicus.Common.CQRS.Events;
using Copernicus.Common.CQRS.Notifications;
using Copernicus.Core.Domain.Games;

namespace Copernicus.Application.Games.Events
{
    public class AnswerCreated : IGameNotification
    {
        public Guid GameId { get; set; }
        public Answer Answer { get; set; }

        public AnswerCreated(Guid gameId, Answer answer)
        {
            GameId = gameId;
            Answer = answer;
        }
    }
}