using System;
using System.Threading.Tasks;
using Copernicus.Common.FacebookClient;
using Copernicus.Core.Domain.Identity;

namespace Copernicus.Application.Identity.Auth
{
    public class FacebookService : IFacebookService
    {
        private readonly IFacebookClient _facebookClient;

        public FacebookService(IFacebookClient facebookClient)
        {
            _facebookClient = facebookClient;
        }

        public async Task<FacebookUser> GetAccount(string accessToken)
        {
            var result = await _facebookClient.Get(
                "me",
                accessToken,
                "fields=id,name,email,first_name,last_name,location,birthday,picture"
            );

            if (result == null || result.first_name == null || result.last_name == null)
            {
                return null;
            }

            return new FacebookUser {
                Id = result.id,
                Name = result.name,
                Email = result.email,
                FirstName = result.first_name,
                LastName = result.last_name,
                Location = result.location?.name,
                Picture = result.picture?.data?.url
            };
        }
    }
}
