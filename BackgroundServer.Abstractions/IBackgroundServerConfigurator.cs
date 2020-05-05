using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundServer.Abstractions
{
    public interface IBackgroundServerConfigurator
    {
        void Configure(IServiceProvider serviceProvider, string connectionString);
    }
}
