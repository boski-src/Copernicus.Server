using System;
using Copernicus.Common.CQRS.Events;
using Copernicus.Common.CQRS.Notifications;

namespace Copernicus.Application.Games.Events
{
    public class GameStarted : IGameNotification
    {
        public Guid GameId { get; set; }

        public GameStarted(Guid gameId)
        {
            GameId = gameId;
        }
    }
}