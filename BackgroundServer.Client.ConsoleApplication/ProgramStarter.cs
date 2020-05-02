using BackgroundServer.Abstractions;
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
        private readonly TopshelfStarter _topshelfStarter;

        public ProgramStarter(IBackgroundServerManager backgroundServerManager, IConfiguration configuration, TopshelfStarter topshelfStarter)
        {
            _backgroundServerManager = backgroundServerManager;
            _configuration = configuration;
            _topshelfStarter = topshelfStarter;
        }

        internal void Start(IHost host)
        {
            var topshelfEnabled = false;
            bool.TryParse(_configuration["BackgroundServer:TopshelfEnabled"], out topshelfEnabled);

            if (topshelfEnabled)
            {
                _topshelfStarter.Start(host);
            }
            else
            {
                _backgroundServerManager.Start(host.Services);
            }

        }
    }
}
