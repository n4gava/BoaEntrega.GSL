using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BoaEntrega.GSL.Core.Consul
{
    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseConsul(this IApplicationBuilder app, ConsulSettings consulSettings)
        {
            var consulClient = app.ApplicationServices.GetRequiredService<IConsulClient>();
            var logger = app.ApplicationServices.GetRequiredService<ILoggerFactory>().CreateLogger("consul");
            var lifetime = app.ApplicationServices.GetRequiredService<IHostApplicationLifetime>();

            var registration = new AgentServiceRegistration()
            {
                ID = consulSettings.ServiceId,
                Name = consulSettings.ServiceName,
                Address = consulSettings.ServiceHost,
                Port = consulSettings.ServicePort
            };

            logger.LogInformation("Registering with Consul");
            consulClient.Agent.ServiceDeregister(registration.ID).ConfigureAwait(false);
            consulClient.Agent.ServiceRegister(registration).ConfigureAwait(false);

            lifetime.ApplicationStopping.Register(() =>
            {
                logger.LogInformation("Unregistering from Consul");
                consulClient.Agent.ServiceDeregister(registration.ID).Wait();
            });
            return app;
        }
    }
}
