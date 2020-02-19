using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace ChalDalTakeHomeProblem
{
    public class SuperActiveUsersService : IUserService
    {
        private readonly IDataLoader _dataLoader;
        private readonly int _superActiveMealCount = 0;
        public SuperActiveUsersService(
            IDataLoader dataLoader,
            IConfigurationRoot configuration
            )
        {
            _dataLoader = dataLoader;
            _superActiveMealCount = Convert.ToInt32(configuration["SuperActiveMealCount"]);
        }
        public string GetUsers(DateTime fromDate, DateTime toDate)
        {
            var allUsersWithMeal = _dataLoader.LoadData();
            var superActiveUserList = from item in allUsersWithMeal
                            where item.Date >= fromDate && item.Date <= toDate
                            group item by new { item.UserID } into g
                            where g.Count() > _superActiveMealCount
                           select g.Key.UserID;
            var users = String.Join(",", superActiveUserList);
            return users;
        }
    }
}
