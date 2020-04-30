using Autofac;
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
            builder.RegisterType<HangfireConfigurator>().AsImplementedInterfaces();
            builder.RegisterType<BackgroundServer>().AsImplementedInterfaces();
            builder.RegisterType<FireAndForgetJobScheduler>().AsImplementedInterfaces();
        }
    }
}
