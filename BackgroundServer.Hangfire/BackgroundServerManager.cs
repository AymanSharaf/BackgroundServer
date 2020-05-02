using BackgroundServer.Abstractions;
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

        public BackgroundServerManager(IBackgroundServerConfigurator backgroundServerConfigurator)
        {
            _backgroundServerConfigurator = backgroundServerConfigurator;
            _backgroundServer = new BackgroundServer(); // Local Default
        }

        public void Start(IServiceProvider serviceProvider)
        {
            _backgroundServerConfigurator.Configure(serviceProvider);
            _backgroundServer.Start();
        }

        public void Stop()
        {
            _backgroundServer.Stop();
        }
    }
}
