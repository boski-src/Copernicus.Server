using System.Threading.Tasks;
using Copernicus.Application.Identity.Queries;
using Copernicus.Common.CQRS.Queries;
using Copernicus.Core.Domain.Identity;
using Copernicus.Core.Repositories;

namespace Copernicus.Application.Identity.Handlers
{
    public class GetAccountHandler : IQueryHandler<GetAccount, User>
    {
        private readonly IUserRepository _userRepository;

        public GetAccountHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(GetAccount query)
        {
            return await _userRepository.FindOne(query.UserId);
        }
    }
}