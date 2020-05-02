using BackgroundServer.Abstractions;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundServer.Hangfire
{
    public class BackgroundServer
    {
        private BackgroundJobServer _backgroundServer;
        public BackgroundServer()
        {
        }
        public void Start()
        {
            if (_backgroundServer == null)
            {
                _backgroundServer = new BackgroundJobServer(); // Hangfire server options go here 
            }
        }

        public void Stop()
        {
            if (_backgroundServer != null)
            {
                _backgroundServer.Dispose();
            }
        }
    }
}
