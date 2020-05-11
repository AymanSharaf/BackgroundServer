using BackgroundServer.Abstractions.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundServer.Abstractions.Schedulers
{
    public interface IRecurringJobScheduler
    {
        void Register(IRecurringJob job);
        void Remove(IRecurringJob job);
    }
}
