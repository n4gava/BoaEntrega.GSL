using BoaEntrega.GSL.Cadastros.Data;
using BoaEntrega.GSL.Cadastros.Data.Repositories;
using BoaEntrega.GSL.Cadastros.Domain;
using BoaEntrega.GSL.Cadastros.Domain.EventsHandlers;
using BoaEntrega.GSL.Cadastros.Domain.Services;
using BoaEntrega.GSL.Core.Consul;
using BoaEntrega.GSL.Core.IntegrationEvents;
using EventBus;
using EventBusRabbitMQ;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using System;
using System.IO;
using System.Reflection;

namespace BoaEntrega.GSL.Cadastros.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public ConsulSettings ConsulSettings { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            ConsulSettings = services.ConfigureConsulSettings(Configuration);
            services.AddDbContext<CadastrosContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddConsulSettings(ConsulSettings);
            services.AddControllers()
                    .AddOData(opt => opt.Count().Filter().Expand().Select().OrderBy().SetMaxTop(5)
                    .AddRouteComponents("api", GetEdmModel())
                );
            services.AddOptions();
            services.AddSwaggerGen(c =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            services.AddAutoMapper(this.GetType().Assembly);

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteServices, ClienteServices>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IFornecedorServices, FornecedorServices>();
            services.AddRabbitMQEventBus(Configuration);
            services.AddScoped<ClienteEventHandlers>();
        }

        protected virtual void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            eventBus.Subscribe<ClienteAtualizadoEvent, ClienteEventHandlers>();
            eventBus.Subscribe<ClienteRemovidoEvent, ClienteEventHandlers>();
            eventBus.Subscribe<ClienteInseridoEvent, ClienteEventHandlers>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, CadastrosContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            dbContext.Database.Migrate();
            app.UseConsul(ConsulSettings);
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            ConfigureEventBus(app);
        }

        public static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Cliente>("clientes");
            builder.EntitySet<Fornecedor>("fornecedores");
            return builder.GetEdmModel();
        }
    }
}
