using System;
using System.Threading.Tasks;
using Copernicus.Application.Identity.Events;
using Copernicus.Common.CQRS.Events;
using Copernicus.Core.Domain.Identity;
using Copernicus.Core.Repositories;

namespace Copernicus.Application.Identity
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEventBus _eventBus;

        public UserService(IUserRepository userRepository, IEventBus eventBus)
        {
            _userRepository = userRepository;
            _eventBus = eventBus;
        }

        public async Task Create(User newUser)
        {
            var user = await _userRepository.FindOne(newUser.Id);
            if (user != null) throw new UserServiceExceptions.AlreadyExists();
            user = await _userRepository.FindOneByEmail(newUser.Email);
            if (user != null) throw new UserServiceExceptions.EmailAlreadyUsed();

            await _userRepository.Create(newUser);
            await _eventBus.Publish(new UserCreated(newUser.Id, newUser.Name));
        }

        public async Task CreateFacebookProvider(Guid id, FacebookUser facebookUser)
        {
            var user = User.CreateFromFacebook(id, facebookUser);
            await Create(user);
        }
    }
}