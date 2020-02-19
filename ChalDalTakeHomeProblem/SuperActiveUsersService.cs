using System;
using System.Linq;

namespace ChalDalTakeHomeProblem
{
    public class SuperActiveUsersService : IUserService
    {
        private readonly IDataLoader _dataLoader;
        public SuperActiveUsersService(
            IDataLoader dataLoader
            )
        {
            _dataLoader = dataLoader;
        }
        public string GetUsers(DateTime fromDate, DateTime toDate)
        {
            var allUsersWithMeal = _dataLoader.LoadData();
            var userList = from item in allUsersWithMeal
                            where item.Date >= fromDate && item.Date <= toDate
                            group item by new { item.UserID } into g
                            where g.Count() > 5
                            select new { g.Key.UserID, Count = g.Count() };
            var users = String.Join(",", userList);
            return users;
        }
    }
}
