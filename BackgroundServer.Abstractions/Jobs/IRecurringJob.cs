using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundServer.Abstractions.Jobs
{
    public interface IRecurringJob: IJob
    {
        string CronExpression { get;}
        void UpdateCronExpression(string expression);
    }
}
