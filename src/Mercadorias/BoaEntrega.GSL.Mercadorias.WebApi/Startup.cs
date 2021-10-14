using BoaEntrega.GSL.Core.Consul;
using BoaEntrega.GSL.Mercadorias.Data;
using BoaEntrega.GSL.Mercadorias.Data.Repositories;
using BoaEntrega.GSL.Mercadorias.Domain;
using BoaEntrega.GSL.Mercadorias.Domain.Services;
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

namespace BoaEntrega.GSL.Mercadorias
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
            services.AddDbContext<MercadoriaContext>(options =>
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

            services.AddScoped<IMercadoriaRepository, MercadoriaRepository>();
            services.AddScoped<IDepositoRepository, DepositoRepository>();
            services.AddScoped<IMercadoriaServices, MercadoriaServices>();
            services.AddScoped<IDepositoServices, DepositoServices>();
            //services.AddRabbitMQEventBus(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MercadoriaContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            dbContext.Database.Migrate();
            
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseConsul(ConsulSettings);
        }

        public static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Mercadoria>("mercadorias");
            builder.EntitySet<Deposito>("depositos");
            return builder.GetEdmModel();
        }
    }
}
