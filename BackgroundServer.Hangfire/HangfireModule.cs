using Autofac;
using BackgroundServer.Abstractions;
using BackgroundServer.Hangfire.Schedulers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundServer.Hangfire
{
    public class HangfireModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HangfireConfigurator>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<BackgroundServer>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<BackgroundServerManager>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<FireAndForgetJobScheduler>().AsImplementedInterfaces();
        }
    }
}
