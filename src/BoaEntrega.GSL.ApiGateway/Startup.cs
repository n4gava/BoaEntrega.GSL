
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Ocelot.Authorisation;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;

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

        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var configuration = new OcelotPipelineConfiguration
            {
                AuthorisationMiddleware = async (ctx, next) =>
                {
                    if (this.Authorize(ctx))
                    {
                        await next.Invoke();
                    }
                    else
                    {
                        ctx.Items.SetError(new UnauthorisedError($"Fail to authorize"));
                    }
                }
            };

            await app.UseOcelot(configuration);
        }

        private bool Authorize(HttpContext ctx)
        {
            if (ctx.Items.DownstreamRoute().AuthenticationOptions.AuthenticationProviderKey == null) return true;
            else
            {
                bool auth = false;
                var claims = ctx.User.Claims.ToArray<Claim>();
                Dictionary<string, string> required = ctx.Items.DownstreamRoute().RouteClaimsRequirement;
                var reor = new Regex(@"[^,\s+$ ][^\,]*[^,\s+$ ]");
                MatchCollection matches;

                Regex reand = new Regex(@"[^&\s+$ ][^\&]*[^&\s+$ ]");
                MatchCollection matchesand;
                int cont = 0;
                foreach (KeyValuePair<string, string> claim in required)
                {
                    matches = reor.Matches(claim.Value);
                    foreach (Match match in matches)
                    {
                        matchesand = reand.Matches(match.Value);
                        cont = 0;
                        foreach (Match m in matchesand)
                        {
                            foreach (Claim cl in claims)
                            {
                                if (cl.Type == claim.Key)
                                {
                                    if (cl.Value == m.Value)
                                    {
                                        cont++;
                                    }
                                }
                            }
                        }
                        if (cont == matchesand.Count)
                        {
                            auth = true;
                            break;
                        }
                    }
                }
                return auth;
            }
        }
    }
}