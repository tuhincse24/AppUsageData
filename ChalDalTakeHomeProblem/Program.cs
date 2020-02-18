using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO;

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

            //Configure AppSettings
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            var configuration = builder.Build();

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
