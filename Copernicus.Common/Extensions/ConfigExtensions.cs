using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Copernicus.Common.Extensions
{
    public static class ConfigExtension
    {
        public static T GetConfig<T>(this IServiceCollection services, string sectionName)
        {
            var serviceProvider = services.BuildServiceProvider();
            var configuration = serviceProvider.GetService<IConfiguration>();

            return configuration.GetSection(sectionName).Get<T>();
        }
    }
}