using System;
using System.Net;
using System.Threading.Tasks;
using Copernicus.Common.Extensions;
using Copernicus.Common.Mvc.ErrorHandler;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Copernicus.Common.Authentication.Token
{
    public class JwtMiddleware : IMiddleware
    {
        private readonly ITokenSessionService _tokenSessionService;
        private readonly JwtConfig _config;
        private readonly ITokenService _tokenService;

        public JwtMiddleware(ITokenSessionService tokenSessionService, JwtConfig config, ITokenService tokenService)
        {
            _tokenSessionService = tokenSessionService;
            _config = config;
            _tokenService = tokenService;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var token = context.Request.Headers[_config.HeaderName]
                               .ToString()
                               .Replace("Bearer ", "");

            var valid = false;
            if (!string.IsNullOrWhiteSpace(token))
            {
                var tokenPayload = _tokenService.GetPayload(token);
                if (tokenPayload.Exp > DateTime.UtcNow.GetTicks())
                {
                    valid = true;
                }
            }
            
            if (valid && !await _tokenSessionService.IsExists(token))
            {
                var error = new ErrorDto(
                    HttpStatusCode.Unauthorized,
                    $"unauthorized_{_config.Name}",
                    $"Unauthorized by header: {_config.HeaderName}."
                );

                context.Response.StatusCode = error.Status;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonConvert.SerializeObject(error));
                return;
            }

            await next(context);
        }
    }
}