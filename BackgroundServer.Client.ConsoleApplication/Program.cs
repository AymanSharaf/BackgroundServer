using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace BackgroundServer.Client.ConsoleApplication
{
    class Program
    {
        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }
        static void Main(string[] args)
        {
            var environmentName = Environment.GetEnvironmentVariable("ENVIRONMENT");

            var builder = new ContainerBuilder();

            var hostBuilder = new HostBuilder()
               .ConfigureAppConfiguration((hostContext, config) =>
               {
                   var builder = config
                         .SetBasePath(AppDomain.CurrentDomain.BaseDirectory.ToString())
                        .AddJsonFile($"appsettings.json", optional: false, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
                        .AddEnvironmentVariables();

                   if (environmentName.Equals("Development"))
                   {
                       builder.AddUserSecrets<Program>();
                   }

               }).UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterAssemblyModules(typeof(Hangfire.BackgroundServer).Assembly);
                builder.RegisterType<ProgramStarter>().SingleInstance();
                builder.RegisterType<TopshelfStarter>().SingleInstance();
            });

            var container = builder.Build();
            var host = hostBuilder.Build();

            var programStarter = container.Resolve<ProgramStarter>();
            programStarter.Start(host);

        }
    }
}
