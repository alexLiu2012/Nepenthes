using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace StackTools.Nepenthes.GraphQL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureHostConfiguration(cfg =>
                {
                    // load default settings from .appsettings
                    //cfg.AddJsonFile("", false, true);
                    // load customized settings

                    cfg.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "webaccess.config.json"), true, true);
                })

                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
