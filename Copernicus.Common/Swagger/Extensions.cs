using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Copernicus.Common.Swagger
{
    public static class Extensions
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(
                c => {
                    c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });

                    var security = new Dictionary<string, IEnumerable<string>> {
                        { "Bearer", new string[] { } }
                    };

                    c.AddSecurityDefinition(
                        "Bearer",
                        new ApiKeyScheme {
                            Description = "JWT Token",
                            Name = "Authorization",
                            In = "header"
                        }
                    );

                    c.AddSecurityRequirement(security);
                }
            );
            return services;
        }

        public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(
                c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                    c.DocExpansion(DocExpansion.None);
                }
            );
            return app;
        }
    }
}