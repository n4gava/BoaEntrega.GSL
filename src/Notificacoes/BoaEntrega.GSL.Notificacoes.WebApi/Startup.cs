using BoaEntrega.GSL.Core.Consul;
using BoaEntrega.GSL.Core.IntegrationEvents;
using BoaEntrega.GSL.Notificacoes.Controllers;
using BoaEntrega.GSL.Notificacoes.Data;
using BoaEntrega.GSL.Notificacoes.Data.Repositories;
using BoaEntrega.GSL.Notificacoes.Domain;
using BoaEntrega.GSL.Notificacoes.Domain.EventHandlers;
using BoaEntrega.GSL.Notificacoes.Domain.Services;
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
using System.Text.Json.Serialization;

namespace BoaEntrega.GSL.Notificacoes.WebApi
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

            services.AddDbContext<NotificacoesContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddConsulSettings(ConsulSettings);

            services.AddControllers().AddJsonOptions(opts =>
            {
                var enumConverter = new JsonStringEnumConverter();
                opts.JsonSerializerOptions.Converters.Add(enumConverter);
            });
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

            services.AddRabbitMQEventBus(Configuration);
            services.AddScoped<INotificacaoRepository, NotificacaoRepository>();
            services.AddScoped<INotificacaoServices, NotificacaoServices>();

            services.AddScoped<SendNotificacaoEventHandler>();
        }

        protected virtual void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            eventBus.Subscribe<SendNotificacao, SendNotificacaoEventHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, NotificacoesContext dbContext)
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
            builder.EntitySet<Notificacao>("notificacoes");
            return builder.GetEdmModel();
        }
    }
}
