using BackgroundServer.Abstractions.Jobs;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundServer.Client.ConsoleApplication.Test
{
    public class HelloWorldRecurringJob : IHelloWorldRecurringJob
    {
        public string CronExpression { get; private set; }
        public HelloWorldRecurringJob()
        {
            UpdateCronExpression(Cron.Minutely());
        }

        public Task Execute()
        {
            Console.WriteLine("Hello World");
            return Task.FromResult(0);
        }

        public void UpdateCronExpression(string expression)
        {
            //Validation here
            CronExpression = expression;
        }
    }
}
