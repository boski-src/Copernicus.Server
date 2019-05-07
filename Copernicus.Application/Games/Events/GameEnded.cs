using System;
using Copernicus.Common.CQRS.Events;
using Copernicus.Common.CQRS.Notifications;

namespace Copernicus.Application.Games.Events
{
    public class GameEnded : IGameNotification, IEvent
    {
        public Guid GameId { get; set; }

        public GameEnded(Guid gameId)
        {
            GameId = gameId;
        }
    }
}