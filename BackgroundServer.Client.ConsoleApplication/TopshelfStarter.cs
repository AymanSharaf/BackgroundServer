using BackgroundServer.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace BackgroundServer.Client.ConsoleApplication
{
    public class TopshelfStarter
    {
        internal void Start(IHost host)
        {
            HostFactory.Run(hostConfigrator =>
            {
                hostConfigrator.Service<IBackgroundServerManager>(service =>
                {
                    service.ConstructUsing(settings =>
                    {
                        var service = host.Services.GetRequiredService<IBackgroundServerManager>();
                        return service;
                    });
                    service.WhenStarted(s =>
                    {
                        s.Start(host.Services);
                    });
                    service.WhenStopped(service => service.Stop());
                });

                hostConfigrator.RunAsLocalSystem()
                  .StartAutomatically();

                //hostConfigrator.SetServiceName("");
                //hostConfigrator.SetDisplayName("");
                //hostConfigrator.SetDescription("");
            });
        }
    }
}
