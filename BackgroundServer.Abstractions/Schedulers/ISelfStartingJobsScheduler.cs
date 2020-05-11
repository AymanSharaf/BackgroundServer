using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundServer.Abstractions.Schedulers
{
    public interface ISelfStartingJobsScheduler
    {
        void Inilialize();
    }
}
