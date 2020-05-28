using BackgroundServer.Abstractions;
using Hangfire;
using System;


namespace BackgroundServer.Hangfire
{
    public class HangfireConfigurator : IBackgroundServerConfigurator
    {
        public HangfireConfigurator()
        { 
        }
        public void Configure(IServiceProvider serviceProvider, string connectionString)
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage(connectionString)
                                      .UseActivator(new HangfireAutofacActivator(serviceProvider))
                                      .UseColouredConsoleLogProvider();
        }
    }
}
