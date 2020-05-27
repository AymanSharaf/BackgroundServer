using BackgroundServer.Abstractions.Jobs;
using BackgroundServer.Abstractions.Schedulers;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundServer.Hangfire.Schedulers
{
    public class RecurringJobScheduler : IRecurringJobScheduler
    {
        public void Register<T>(T job) where T : class, IRecurringJob
        {
            var jobName = job.GetType().GetInterfaces().First().Name;
            RecurringJob.RemoveIfExists(jobName);
            RecurringJob.AddOrUpdate<T>(jobName, job => job.Execute(), job.CronExpression, TimeZoneInfo.Utc);
        }

        public void Remove<T>(T job) where T : class, IRecurringJob
        {
            RecurringJob.RemoveIfExists(job.GetType().Name);
        }
    }
}
