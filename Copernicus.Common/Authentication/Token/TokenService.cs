using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Copernicus.Common.Extensions;
using Microsoft.IdentityModel.Tokens;

namespace Copernicus.Common.Authentication.Token
{
    public class TokenService : ITokenService
    {
        private JwtSecurityTokenHandler _jwtSecurityTokenHandler;
        private JwtConfig _config;

        public TokenService(JwtSecurityTokenHandler jwtSecurityTokenHandler, JwtConfig config)
        {
            _jwtSecurityTokenHandler = jwtSecurityTokenHandler;
            _config = config;
        }

        public string Create(Guid userId, string role = null)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var now = DateTime.UtcNow;

            var jwtClaims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.GetTicks().ToString())
            };

            if (!string.IsNullOrWhiteSpace(role))
            {
                jwtClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var token = new JwtSecurityToken(
                issuer: _config.Issuer,
                audience: _config.Issuer,
                claims: jwtClaims,
                notBefore: now,
                expires: now.AddMinutes(_config.LifetimeInMinutes),
                signingCredentials: credentials
            );

            return _jwtSecurityTokenHandler.WriteToken(token);
        }

        public JwtPayload GetPayload(string token)
        {
            return _jwtSecurityTokenHandler.ReadJwtToken(token).Payload;
        }
    }
}