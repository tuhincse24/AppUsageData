using System;
using System.Collections.Generic;
using System.Text;

namespace ChalDalTakeHomeProblem
{
    public interface IUsersServiceProvider
    {
        IUserService GetUserService(string userActivityStatus);
    }
    public class UsersServiceProvider : IUsersServiceProvider
    {
        private readonly SuperActiveUsersService _superActiveUsersService;
        public UsersServiceProvider(
            SuperActiveUsersService superActiveUsersService
            )
        {
            _superActiveUsersService = superActiveUsersService;
        }
        public IUserService GetUserService(string userActivityStatus)
        {
            switch (userActivityStatus)
            {
                case "superactive":
                    return _superActiveUsersService;
                case "active":
                    return _superActiveUsersService;
                case "board":
                    return _superActiveUsersService;
                default:
                    return null;
            }
        }
    }
}
