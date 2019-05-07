using Microsoft.Extensions.DependencyInjection;

namespace Copernicus.Common.TaskExecutor
{
    public static class Extensions
    {
        public static IServiceCollection AddTaskExecutor(this IServiceCollection services)
        {
            services.AddTransient<ITaskExecutor, TaskExecutor>();
            return services;
        }
    }
}