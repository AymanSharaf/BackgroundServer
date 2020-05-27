# **Background Server**

The requirement was to have an engine to handle background jobs for tasks like (send notifications, calculate monthly bills..etc) also serve very basic workflow scenarios.

# **Solution**
Use Hangfire + Topshelf to create a windows service to serve as the background server.
Topshelf can be replaced with docker + orchestration.

# **How to use**
`BackgroundServer.Abstractions` project should be referenced in an application (use case) level/layer and used as follows:

 1. **Fire and Forget** jobs: 
Use `IFireAndForgetJobScheduler` to run tasks in the background instantly or with a delay
>`var jobId = _fireAndForgetJobScheduler.EnqueueJob<SomeType>(x=>x.SomeMethod)`

Also run method after a fire and forget job ends instantly or with a delay
> _fireAndForgetJobScheduler.ContinueWith<SomeType\>(jobId, x=> x.SomeOtherMethod) 
 2. **Self Starting** jobs:
For scenarios in which it is need to run some tasks upon the start of the Background Server

 3. **Recurring** jobs
 Create an interface that implements `IRecurringJob` then implement that interface and provide the cron expression (preferably in the constructor) as follows

```
    public interface IHelloWorldRecurringJob: IRecurringJob
    {
    }
```
```
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
```
Then there are to options to register this job

 1. Using `IRecurringJobScheduler.Register` Method
 2. Setting `initializeRecurringJobs` to true in `IBackgroundServerManager.Start`


# **How to run**
 1. Console Application
 
   Just run the solution or start BackgroundServer.Client.ConsoleApplication.exe
   
 2. Windows Service
 
	 1. Publish the application as self-contained app
	 2. Open as administrator in the path of the deployment files
	 3. Run dotnet BackgroundServer.Client.ConsoleApplication.dll install
	 4. Run dotnet BackgroundServer.Client.ConsoleApplication.dll start
   
    Stop the service : 
    Run `dotnet BackgroundServer.Client.ConsoleApplication.dll stop`

    Uninstall the service: 
    Run `Run dotnet BackgroundServer.Client.ConsoleApplication.dll uninstall`

3. Docker Container

	`>docker-compose build`
  
	`>docker-compose up`
	
  
 
