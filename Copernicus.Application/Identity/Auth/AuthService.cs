using System;
using System.Threading.Tasks;
using Copernicus.Application.Identity.Events;
using Copernicus.Common.Authentication.Token;
using Copernicus.Common.CQRS.Events;
using Copernicus.Core.Domain.Identity;
using Copernicus.Core.Repositories;

namespace Copernicus.Application.Identity.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IFacebookService _facebookService;
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        private readonly ISessionService _sessionService;

        public AuthService(IUserRepository userRepository,
            IFacebookService facebookService,
            IUserService userService,
            ITokenService tokenService,
            ISessionService sessionService)
        {
            _userRepository = userRepository;
            _facebookService = facebookService;
            _userService = userService;
            _tokenService = tokenService;
            _sessionService = sessionService;
        }

        public async Task<string> SignInViaFacebook(string accessToken)
        {
            var facebookUser = await _facebookService.GetAccount(accessToken);

            if (facebookUser == null)
                throw new UserServiceExceptions.NotFound();

            var user = await _userRepository.FindOneByProvider(Providers.Facebook, facebookUser.Id);
            if (user == null)
            {
                var id = Guid.NewGuid();
                await _userService.CreateFacebookProvider(id, facebookUser);
                user = await _userRepository.FindOne(id);
            }
            else
            {
                user.SetAvatar(facebookUser.Picture);
                await _userRepository.Update(user);
            }

            var token = _tokenService.Create(user.Id, user.Role);
            await _sessionService.Create(token);

            return token;
        }
    }
}