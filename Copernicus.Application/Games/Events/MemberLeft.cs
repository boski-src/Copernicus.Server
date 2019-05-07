using System;
using Copernicus.Common.CQRS.Events;
using Copernicus.Common.CQRS.Notifications;

namespace Copernicus.Application.Games.Events
{
    public class MemberLeft : IGameNotification
    {
        public Guid GameId { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }

        public MemberLeft(Guid gameId, Guid userId, string userName)
        {
            GameId = gameId;
            UserId = userId;
            UserName = userName;
        }
    }
}