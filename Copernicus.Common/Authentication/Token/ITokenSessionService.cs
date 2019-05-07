using System;
using System.Threading.Tasks;

namespace Copernicus.Common.Authentication.Token
{
    public interface ITokenSessionService
    {
        Task Create(string token, DateTime expiresAt);
        Task<bool> IsExists(string token);
        Task Delete(string token);
    }
}