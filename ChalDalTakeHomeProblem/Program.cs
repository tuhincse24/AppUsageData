using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace ChalDalTakeHomeProblem
{
    class Program
    {
        static void Main(string[] args)
        {

            //Configure AppSettings
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            var configuration = builder.Build();

            //Setup our DI
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IDataLoader, DataLoader>()
                .AddSingleton<IUsersServiceProvider, UsersServiceProvider>()
                //.AddSingleton<IConfiguration, Configuration>()
                .AddSingleton<SuperActiveUsersService>()
                .AddSingleton(provider => configuration)
                .BuildServiceProvider();

            //Configure console logging
            serviceProvider
                .GetService<ILoggerFactory>();
                //.AddConsole(LogLevel.Debug);

            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();
            logger.LogDebug("Starting application");

            //So the actual work here
            var userServiceProvider = serviceProvider.GetService<IUsersServiceProvider>();
            var userService = userServiceProvider.GetUserService("superactive");
            var fromDate = Convert.ToDateTime(args[1]);
            var toDate = Convert.ToDateTime(args[2]);
            var users = userService.GetUsers(fromDate, toDate);
            logger.LogDebug("All done!");
        }
    }
}
