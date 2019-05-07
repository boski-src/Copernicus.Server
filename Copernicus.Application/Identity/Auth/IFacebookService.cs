using System.Threading.Tasks;
using Copernicus.Core.Domain.Identity;

namespace Copernicus.Application.Identity.Auth
{
    public interface IFacebookService
    {
        Task<FacebookUser> GetAccount(string accessToken);
    }
}