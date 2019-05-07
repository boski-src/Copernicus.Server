using System;

namespace Copernicus.Core.Domain.Games
{
    public class Member
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserAvatarUrl { get; set; }
        public bool IsCreator { get; set; }
        public bool IsOnline { get; set; }

        protected Member()
        {
        }

        protected Member(Guid userId, string userName, string userAvatarUrl, bool isCreator = false)
        {
            UserId = userId;
            UserName = userName;
            UserAvatarUrl = userAvatarUrl;
            IsCreator = isCreator;
        }

        public void SetOnline(bool online)
        {
            IsOnline = online;
        }

        public static Member CreateFromCreator(Guid userId, string userName, string userAvatarUrl)
            => new Member(userId, userName, userAvatarUrl, true);

        public static Member Create(Guid userId, string userName, string userAvatarUrl)
            => new Member(userId, userName, userAvatarUrl);
    }
}