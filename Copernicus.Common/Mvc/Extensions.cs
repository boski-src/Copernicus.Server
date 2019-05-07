using System.Reflection;
using Copernicus.Common.Mvc.ErrorHandler;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Copernicus.Common.Mvc
{
    public static class Extensions
    {
        public static string CorsOrigin = "AllowCorsPolicy";

        public static IServiceCollection AddCustomMvc(this IServiceCollection services)
        {
            services.AddCors(
                opts => opts.AddPolicy(
                    CorsOrigin,
                    builder => builder
                               .AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyMethod()
                               .AllowCredentials()
                               .WithOrigins("http://localhost:4200", "https://copernicus.top", "https://play.copernicus.top", "https://www.copernicus.top")
                )
            );
            services.AddMvc()
                    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(Assembly.GetEntryAssembly()));

            return services;
        }

        public static IApplicationBuilder UseCustomMvc(this IApplicationBuilder app)
        {
            app.UseCors(CorsOrigin);
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseMvc();

            return app;
        }
    }
}