using BackgroundServer.Abstractions;
using Hangfire;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
