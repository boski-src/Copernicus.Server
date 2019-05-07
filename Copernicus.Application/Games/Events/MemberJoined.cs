using System;
using Copernicus.Common.CQRS.Events;
using Copernicus.Common.CQRS.Notifications;

namespace Copernicus.Application.Games.Events
{
    public class MemberJoined : IGameNotification
    {
        public Guid GameId { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserAvatarUrl { get; set; }

        public MemberJoined(Guid gameId, Guid userId, string userName, string userAvatarUrl)
        {
            GameId = gameId;
            UserId = userId;
            UserName = userName;
            UserAvatarUrl = userAvatarUrl;
        }
    }
}
