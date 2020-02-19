using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace ChalDalTakeHomeProblem
{
    public class ActiveUsersService : IUserService
    {
        private readonly IDataLoader _dataLoader;
        private readonly int _activeMealCount = 0;
        public ActiveUsersService(
            IDataLoader dataLoader,
            IConfigurationRoot configuration
            )
        {
            _dataLoader = dataLoader;
            _activeMealCount = Convert.ToInt32(configuration["ActiveMealCount"]);
        }
        public string GetUsers(DateTime fromDate, DateTime toDate)
        {
            var allUsersWithMeal = _dataLoader.LoadData();
            var activeUserList = from item in allUsersWithMeal
                            where item.Date >= fromDate && item.Date <= toDate
                            group item by new { item.UserID } into g
                            where g.Count() >= _activeMealCount
                           select g.Key.UserID;
            var users = String.Join(",", activeUserList);
            return users;
        }
    }
}
