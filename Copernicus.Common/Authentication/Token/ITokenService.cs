using System;
using System.IdentityModel.Tokens.Jwt;

namespace Copernicus.Common.Authentication.Token
{
    public interface ITokenService
    {
        string Create(Guid userId, string role = null);
        JwtPayload GetPayload(string token);
    }
}