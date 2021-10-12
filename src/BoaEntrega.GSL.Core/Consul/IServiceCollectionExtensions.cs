using Consul;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace BoaEntrega.GSL.Core.Consul
{
    public static class IServiceCollectionExtensions
    {
        public static ConsulSettings ConfigureConsulSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConsulSettings>(configuration.GetSection(nameof(ConsulSettings)));
            var serviceProvider = services.BuildServiceProvider();
            var iop = serviceProvider.GetService<IOptions<ConsulSettings>>();
            return iop.Value;
        }

        public static IServiceCollection AddConsulSettings(this IServiceCollection services, ConsulSettings consulSettings)
        {
            services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(config =>
            {
                config.Address = new Uri(consulSettings.ServiceDiscoveryAddress);
            }));

            return services;
        }
    }
}
