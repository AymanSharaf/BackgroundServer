using BackgroundServer.Abstractions.Schedulers;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundServer.Hangfire.Schedulers
{
    public class FireAndForgetJobScheduler : IFireAndForgetJobScheduler
    {
        public string ContinueJobWith<T>(string parentJobId, Expression<Action<T>> methodCall)
        {
            return BackgroundJob.ContinueJobWith(parentJobId, methodCall);
        }

        public string EnqueueJob<T>(Expression<Action<T>> methodCall)
        {
            return BackgroundJob.Enqueue<T>(methodCall);
        }
    }
}
