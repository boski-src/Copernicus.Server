using System.Threading.Tasks;

namespace Copernicus.Application.Identity.Auth
{
    public interface ISessionService
    {
        Task Create(string token);
        Task Refresh(string token);
        Task Destroy(string token);
    }
}