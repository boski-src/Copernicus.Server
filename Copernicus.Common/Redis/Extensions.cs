using Copernicus.Common.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Copernicus.Common.Redis
{
    public static class Extensions
    {
        public static IServiceCollection AddRedis(this IServiceCollection services)
        {
            var config = services.GetConfig<RedisConfig>("Redis");

            services.AddSingleton(config);
            services.AddDistributedRedisCache(
                opts => {
                    opts.Configuration = config.Connection;
                    opts.InstanceName = config.Instance;
                }
            );

            return services;
        }
    }
}