namespace ChalDalTakeHomeProblem
{
    public interface IUsersServiceProvider
    {
        IUserService GetUserService(string userActivityStatus);
    }
    public class UsersServiceProvider : IUsersServiceProvider
    {
        private readonly SuperActiveUsersService _superActiveUsersService;
        private readonly ActiveUsersService _activeUsersService;
        private readonly BoredUsersService _boredUserService;
        public UsersServiceProvider(
            SuperActiveUsersService superActiveUsersService,
            ActiveUsersService activeUsersService,
            BoredUsersService boredUserService
            )
        {
            _superActiveUsersService = superActiveUsersService;
            _activeUsersService = activeUsersService;
            _boredUserService = boredUserService;
        }
        public IUserService GetUserService(string userActivityStatus)
        {
            switch (userActivityStatus)
            {
                case "superactive":
                    return _superActiveUsersService;
                case "active":
                    return _activeUsersService;
                case "bored":
                    return _boredUserService;
                default:
                    return null;
            }
        }
    }
}
