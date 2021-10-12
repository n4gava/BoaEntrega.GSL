using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace BoaEntrega.GSL.Cadastros.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseKestrel(options =>
                        {
                            options.AddServerHeader = false;
                            options.ListenAnyIP(9004);
                        })
                        .UseStartup<Startup>();
                });
    }
}