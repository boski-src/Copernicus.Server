using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;

namespace Copernicus.Common.Authentication.Token
{
    public class RedisTokenSessionService : ITokenSessionService
    {
        private readonly IDistributedCache _distributedCache;
        private readonly JwtConfig _config;

        public RedisTokenSessionService(IDistributedCache distributedCache, JwtConfig config)
        {
            _distributedCache = distributedCache;
            _config = config;
        }

        public async Task Create(string token, DateTime expiresAt)
        {
            var options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(GetExpiryTimeSpan(expiresAt));
            await _distributedCache.SetStringAsync(GetKeyString(token), "true", options);
        }

        public async Task<bool> IsExists(string token)
        {
            var key = await _distributedCache.GetStringAsync(GetKeyString(token));
            return key != null;
        }

        public async Task Delete(string token)
        {
            await _distributedCache.RemoveAsync(GetKeyString(token));
        }

        private string GetKeyString(string token)
        {
            return $"{_config.Name}#{token}";
        }

        private TimeSpan GetExpiryTimeSpan(DateTime expiresAt)
        {
            var expires = expiresAt;
            var expiryTimeSpan = expires.Subtract(DateTime.UtcNow);
            return expiryTimeSpan;
        }
    }
}