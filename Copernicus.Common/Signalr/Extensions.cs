using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;

namespace Copernicus.Common.Signalr
{
    public static class Extensions
    {
        public static IServiceCollection AddHub<THub>(this IServiceCollection services) where THub : Hub
        {
            services.AddScoped<THub>();
            services.AddTransient<IPublishProvider<THub>, PublishProvider<THub>>();

            return services;
        }

        public static IApplicationBuilder UseHub<THub>(this IApplicationBuilder app, string routePath) where THub : Hub
        {
            app.UseSignalR(route => { route.MapHub<THub>(routePath); });

            return app;
        }
    }
}