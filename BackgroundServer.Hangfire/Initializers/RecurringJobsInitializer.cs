using BackgroundServer.Abstractions.Jobs;
using BackgroundServer.Abstractions.Schedulers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundServer.Hangfire.Initializers
{
    public class RecurringJobsInitializer
    {
        private readonly List<IRecurringJob> _recurringJobs;
        private readonly IRecurringJobScheduler _recurringJobScheduler;

        public RecurringJobsInitializer(IRecurringJob[] recurringJobs, IRecurringJobScheduler recurringJobScheduler)
        {
            _recurringJobs = recurringJobs.ToList();
            _recurringJobScheduler = recurringJobScheduler;
        }

        internal void Initialize() 
        {
            _recurringJobs.ForEach(job => _recurringJobScheduler.Register(job));
        }
    }
}
