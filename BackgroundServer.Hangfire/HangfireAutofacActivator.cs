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
            return serviceProvider.GetService(jobType);
        }
    }
}
