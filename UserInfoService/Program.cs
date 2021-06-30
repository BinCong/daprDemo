using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Oxygen.Server.Kestrel.Implements;
using Oxygen.IocModule;
using System.IO;
using Autofac;
using aspnetcoreDemo.Core.Common;
using aspnetcoreDemo.Core.Extension;
using aspnetcoreDemo.Core.IServices;

namespace UserInfoService
{
    public class Program
    {
        private static IConfiguration _configuration;

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
                Host.CreateDefaultBuilder(args)
                    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.StartOxygenServer<OxygenStartup>((config) =>
                        {
                            config.Port = 9007;
                            config.PubSubCompentName = "pubsub";
                            config.StateStoreCompentName = "statestore";
                            config.TracingHeaders = "Authentication,AuthIgnore";
                            config.UseStaticFiles = true;
                            config.UseCors = true;
                        });
                        
                    })
                   .ConfigureAppConfiguration((context, config) =>
                   {
                       config.SetBasePath(Directory.GetCurrentDirectory());
                       config.AddJsonFile("appsettings.json");
                       _configuration = config.Build();
                   })
                  .ConfigureContainer<ContainerBuilder>(builder =>
                  {
                      builder.RegisterOxygenModule();

                      builder.RegisterModule(new ServiceModule());

                      builder.RegisterType<UserInfoBizService>().As<IUserInfoService>().InstancePerLifetimeScope();
                  })
                 .ConfigureServices((context, services) =>
                 {
                     services.AddSingleton(new Appsettings(_configuration));

                     services.AddSqlsugarSetup();

                     services.AddDbSetup();

                     services.AddLogging(con =>
                     {
                         con.AddConfiguration(_configuration.GetSection("Logging"));
                         con.AddConsole();
                     });

                     services.AddAutofac();
                 });
    }
}
