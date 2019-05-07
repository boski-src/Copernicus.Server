using System;
using System.Threading.Tasks;
using Copernicus.Core.Domain.Identity;

namespace Copernicus.Core.Repositories
{
    public interface IUserRepository
    {
        Task Create(User user);
        Task<User> FindOne(Guid id);
        Task<User> FindOneByEmail(string email);
        Task<User> FindOneByProvider(string providerName, string providerId);
        Task Update(User user);
    }
}