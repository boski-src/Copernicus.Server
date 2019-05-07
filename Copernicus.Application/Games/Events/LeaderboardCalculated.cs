using System;
using Copernicus.Common.CQRS.Events;
using Copernicus.Common.CQRS.Notifications;

namespace Copernicus.Application.Games.Events
{
    public class LeaderboardCalculated : IGameNotification, IEvent
    {
        public Guid GameId { get; set; }

        public LeaderboardCalculated(Guid gameId)
        {
            GameId = gameId;
        }
    }
}