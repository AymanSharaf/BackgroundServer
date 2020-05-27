using BackgroundServer.Abstractions.Jobs;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundServer.Hangfire
{
    public class HangfireAutofacActivator : JobActivator
    {
        private readonly IServiceProvider serviceProvider;

        public HangfireAutofacActivator(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        public override object ActivateJob(Type jobType)
        {
            if (jobType.GetInterface(typeof(IRecurringJob).Name )!= null)
            {

                var recurringJobInterface = jobType.GetInterfaces().Single(i=>!i.Name.Equals(typeof(IRecurringJob).Name) && !i.Name.Equals(typeof(IJob).Name));
                return serviceProvider.GetService(recurringJobInterface);

            }
            return serviceProvider.GetService(jobType);
        }
    }
}
