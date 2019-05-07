using System.Threading.Tasks;

namespace Copernicus.Application.Identity.Auth
{
    public interface IAuthService
    {
        Task<string> SignInViaFacebook(string accessToken);
    }
}