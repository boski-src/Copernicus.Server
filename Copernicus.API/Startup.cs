using AutoMapper;
using Copernicus.API.Framework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Copernicus.Application;
using Copernicus.Common.Authentication;
using Copernicus.Common.CQRS;
using Copernicus.Common.Mongo;
using Copernicus.Common.Mvc;
using Copernicus.Common.Redis;
using Copernicus.Common.Signalr;
using Copernicus.Common.Swagger;
using Copernicus.Core.Domain.Games;
using Copernicus.Core.Domain.Identity;
using Copernicus.Core.Domain.Players;
using Copernicus.Core.Domain.Questions;
using Copernicus.Infrastructure;
using Copernicus.Infrastructure.Signalr;
using Microsoft.AspNetCore.HttpOverrides;
using Newtonsoft.Json.Serialization;


namespace Copernicus.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddJwtAuthentication();
            services.AddCustomMvc();
            services.AddApplicationContainer();
            services.AddInfrastructureContainer();

            services.AddCQRS();
            services.AddRedis();
            services.AddMongo()
                    .AddMongoRepository<Game>("games")
                    .AddMongoRepository<User>("users")
                    .AddMongoRepository<Player>("players")
                    .AddMongoRepository<Question>("questions");
            services.AddSingleton<IMapper>(AutoMapperConfig.Configure());

            services.AddSignalR();
            services.AddHub<GameHub>();

            services.AddCustomSwagger();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCustomSwagger();
            }

            app.UseJwtTokenMiddleware();
            app.UseCustomMvc();
            app.UseHub<GameHub>("/hubs/game");
        }
    }
}