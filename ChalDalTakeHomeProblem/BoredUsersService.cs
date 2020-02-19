using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace ChalDalTakeHomeProblem
{
    public class BoredUsersService : IUserService
    {
        private readonly IDataLoader _dataLoader;
        private readonly int _activeMealCount = 0;
        public BoredUsersService(
            IDataLoader dataLoader,
            IConfigurationRoot configuration
            )
        {
            _dataLoader = dataLoader;
            _activeMealCount = Convert.ToInt32(configuration["ActiveMealCount"]);
        }
        public string GetUsers(DateTime fromDate, DateTime toDate)
        {
            var dayDiff = toDate - fromDate;
            var fromDateForActive = fromDate.AddDays(-1 * dayDiff.Days + 1);
            var toDateForActive = toDate.AddDays(-1 * dayDiff.Days + 1);
            var allUsersWithMeal = _dataLoader.LoadData();
            var activeUserList = from item in allUsersWithMeal
                           where item.Date >= fromDateForActive && item.Date <= toDateForActive
                                 group item by new { item.UserID } into g
                           where g.Count() >= _activeMealCount
                                 select g.Key.UserID;

            var boredUserList = from item in allUsersWithMeal
                                join activeUser in activeUserList on item.UserID equals activeUser
                            where item.Date >= fromDate && item.Date <= toDate
                            group item by new { item.UserID } into g
                            where g.Count() < 5
                            select g.Key.UserID;

            var users = String.Join(",", boredUserList);
            return users;
        }
    }
}
