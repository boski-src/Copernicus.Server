using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Copernicus.Common.Authentication.Token;
using Copernicus.Common.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Copernicus.Common.Authentication
{
    public static class Extensions
    {
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services,
            string configSection = "JWTAuth")
        {
            var config = services.GetConfig<JwtConfig>(configSection);

            services.AddSingleton(config);
            services.AddSingleton<ITokenService, TokenService>();
            services.AddSingleton<ITokenSessionService, RedisTokenSessionService>();
            services.AddTransient<JwtSecurityTokenHandler>();
            services.AddTransient<JwtMiddleware>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(
                        options => { options.TokenValidationParameters = config.GetTokenValidationParameters(); }
                    );

            services.AddAuthorization(
                opts => {
                    opts.AddPolicy(
                        "admin",
                        policy => {
                            policy.RequireAuthenticatedUser();
                            policy.RequireRole("admin");
                        }
                    );
                }
            );

            return services;
        }

        public static IApplicationBuilder UseJwtTokenMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<JwtMiddleware>();
            return app;
        }

        public static TokenValidationParameters GetTokenValidationParameters(this JwtConfig tokenConfig)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfig.Secret));

            return new TokenValidationParameters {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = tokenConfig.Issuer,
                ValidAudience = tokenConfig.Issuer,
                IssuerSigningKey = signingKey
            };
        }
    }
}