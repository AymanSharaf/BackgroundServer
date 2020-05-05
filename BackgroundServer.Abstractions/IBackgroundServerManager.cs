using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundServer.Abstractions
{
    public interface IBackgroundServerManager
    {
        void Start(IServiceProvider serviceProvider, string connectionString);
        void Stop();
    }
}
