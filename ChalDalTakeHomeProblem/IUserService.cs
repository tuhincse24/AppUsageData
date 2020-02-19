using System;

namespace ChalDalTakeHomeProblem
{
    public interface IUserService
    {
        string GetUsers(DateTime fromDate, DateTime toDate);
    }
}
