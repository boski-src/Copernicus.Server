using System;
using System.Threading.Tasks;
using Copernicus.Core.Domain.Identity;

namespace Copernicus.Application.Identity
{
    public interface IUserService
    {
        Task Create(User newUser);
        Task CreateFacebookProvider(Guid id, FacebookUser facebookUser);
    }
}