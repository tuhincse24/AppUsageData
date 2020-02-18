using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ChalDalTakeHomeProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            //Setup our DI
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IDataLoader, DataLoader>()
                .BuildServiceProvider();

            //Configure console logging
            serviceProvider
                .GetService<ILoggerFactory>();
                //.AddConsole(LogLevel.Debug);

            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();
            logger.LogDebug("Starting application");

            //So the actual work here
            var dataLoader = serviceProvider.GetService<IDataLoader>();
            dataLoader.LoadData();

            logger.LogDebug("All done!");
        }
    }
}
