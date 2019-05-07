using System;

namespace Copernicus.Infrastructure.Signalr
{
    public static class GroupExtensions
    {
        public static string ToUserGroup(this Guid userId) => $"users:{userId}";
        public static string ToGameGroup(this Guid gameId) => $"games:{gameId}";
    }
}