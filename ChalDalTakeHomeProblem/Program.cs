using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

            //Setup DI
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IDataLoader, DataLoader>()
                .AddSingleton<IUsersServiceProvider, UsersServiceProvider>()
                .AddSingleton<SuperActiveUsersService>()
                .AddSingleton<ActiveUsersService>()
                .AddSingleton<BoredUsersService>()
                .AddSingleton(provider => configuration)
                .BuildServiceProvider();

            Console.WriteLine("Starting application");

            //The actual work here
            var userServiceProvider = serviceProvider.GetService<IUsersServiceProvider>();
            var userService = userServiceProvider.GetUserService(args[0]);
            if (userService != null)
            {
                var fromDate = Convert.ToDateTime(args[1]);
                var toDate = Convert.ToDateTime(args[2]);
                var users = userService.GetUsers(fromDate, toDate);
                Console.WriteLine($"List of comma- separated '{args[0].ToUpper()}' user ids: ({users})");
            }
            else
            {
                Console.WriteLine($"No service found for activity: {args[0]}");
            }
            Console.WriteLine("All done!");
            Console.ReadLine();
        }
    }
}
