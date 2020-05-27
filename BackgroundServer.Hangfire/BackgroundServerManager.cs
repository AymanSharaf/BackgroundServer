using BackgroundServer.Abstractions;
using BackgroundServer.Hangfire.Initializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundServer.Hangfire
{
    public class BackgroundServerManager : IBackgroundServerManager
    {
        private readonly BackgroundServer _backgroundServer;
        private readonly IBackgroundServerConfigurator _backgroundServerConfigurator;
        private readonly RecurringJobsInitializer _recurringJobsInitializer;

        public BackgroundServerManager(IBackgroundServerConfigurator backgroundServerConfigurator, RecurringJobsInitializer recurringJobsInitializer)
        {
            _backgroundServerConfigurator = backgroundServerConfigurator;
            _recurringJobsInitializer = recurringJobsInitializer;
            _backgroundServer = new BackgroundServer(); // Local Default
        }

        public void Start(IServiceProvider serviceProvider, string connectionString, bool initializeRecurringJobs = false)
        {
            _backgroundServerConfigurator.Configure(serviceProvider, connectionString);
            _backgroundServer.Start();

            if (initializeRecurringJobs)
            {
                _recurringJobsInitializer.Initialize();
            }
        }

        public void Stop()
        {
            _backgroundServer.Stop();
        }
    }
}
