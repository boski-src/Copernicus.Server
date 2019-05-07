using System;
using System.Threading.Tasks;
using Copernicus.Common.Authentication.Token;

namespace Copernicus.Application.Identity.Auth
{
    public class SessionService : ISessionService
    {
        private readonly ITokenSessionService _tokenSessionService;
        private readonly JwtConfig _jwtConfig;

        public SessionService(ITokenSessionService tokenSessionService, JwtConfig jwtConfig)
        {
            _tokenSessionService = tokenSessionService;
            _jwtConfig = jwtConfig;
        }

        public async Task Create(string token)
        {
            await _tokenSessionService.Create(token, DateTime.UtcNow.AddMinutes(_jwtConfig.LifetimeInMinutes));
        }

        public async Task Refresh(string token)
        {
            await _tokenSessionService.Create(token, DateTime.UtcNow.AddMinutes(_jwtConfig.LifetimeInMinutes));
        }

        public async Task Destroy(string token)
        {
            await _tokenSessionService.Delete(token);
        }
    }
}