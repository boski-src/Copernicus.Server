using System;
using Copernicus.Common.CQRS.Events;

namespace Copernicus.Application.Identity.Events
{
    public class UserCreated : IEvent
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }

        public UserCreated(Guid userId, string userName)
        {
            UserId = userId;
            UserName = userName;
        }
    }
}