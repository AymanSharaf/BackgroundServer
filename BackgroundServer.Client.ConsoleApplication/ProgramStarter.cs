using BackgroundServer.Abstractions;
using BackgroundServer.Abstractions.Schedulers;
using BackgroundServer.Client.ConsoleApplication.Test;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundServer.Client.ConsoleApplication
{
    public class ProgramStarter
    {
        private readonly IBackgroundServerManager _backgroundServerManager;
        private readonly IConfiguration _configuration;
        private readonly IRecurringJobScheduler _recurringJobScheduler;
        private readonly TopshelfStarter _topshelfStarter;

        public ProgramStarter(IBackgroundServerManager backgroundServerManager,
                              IConfiguration configuration,
                              IRecurringJobScheduler recurringJobScheduler,
                              TopshelfStarter topshelfStarter)
        {
            _backgroundServerManager = backgroundServerManager;
            _configuration = configuration;
            _recurringJobScheduler = recurringJobScheduler;
            _topshelfStarter = topshelfStarter;
        }

        internal void Start(IHost host)
        {
            var topshelfEnabled = false;
            bool.TryParse(_configuration["BackgroundServer:TopshelfEnabled"], out topshelfEnabled);
            var connectionString = _configuration["BackgroundServer:HangfireConnectionString"];

            if (topshelfEnabled)
            {
                _topshelfStarter.Start(host, connectionString);
            }
            else
            {
                _backgroundServerManager.Start(host.Services, connectionString);
                var job = new HelloWorldRecurringJob();
                _recurringJobScheduler.Register(job);
                Console.ReadLine();
            }

        }
    }
}
