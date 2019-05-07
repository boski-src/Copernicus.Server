using System.Threading.Tasks;

namespace Copernicus.Common.FacebookClient
{
    public interface IFacebookClient
    {
        Task<dynamic> Get(string endpoint, string accessToken, string args = "");
    }
}