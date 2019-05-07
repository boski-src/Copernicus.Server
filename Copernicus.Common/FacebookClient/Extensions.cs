using Copernicus.Common.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Copernicus.Common.FacebookClient
{
    public static class Extensions
    {
        public static IServiceCollection AddFacebookClient(this IServiceCollection services,
            string facebookConfigSection = "FacebookClient")
        {
            var config = services.GetConfig<FacebookConfig>(facebookConfigSection);

            services.AddSingleton(config);
            services.AddSingleton<IFacebookClient>(new FacebookClient(config.Url));

            return services;
        }
    }
}