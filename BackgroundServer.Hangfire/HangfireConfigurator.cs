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
        private readonly IConfiguration _configuration;

        public HangfireConfigurator(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void Configure(IServiceProvider serviceProvider)
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage(_configuration["BackgroundServer:HangfireConnectionString"])
                                      .UseActivator(new HangfireAutofacActivator(serviceProvider))
                                      .UseColouredConsoleLogProvider();
        }
    }
}
