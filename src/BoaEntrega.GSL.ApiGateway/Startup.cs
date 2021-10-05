
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;
using System.Text;

namespace BoaEntrega.GSL.ApiGateway
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true)
                .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"ocelot.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var authenticationProviderKey = "BaseAuth";
            var key = Encoding.ASCII.GetBytes("9a35787f-665f-4439-b5bc-b6a8dd08987a");

            services.AddAuthentication()
                .AddJwtBearer(authenticationProviderKey, options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services
                .AddOcelot(Configuration)
                .AddConsul();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseOcelot().Wait();
        }
    }
}