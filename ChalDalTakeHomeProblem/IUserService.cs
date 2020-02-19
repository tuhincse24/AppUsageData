using System;
using System.Collections.Generic;
using System.Text;

namespace ChalDalTakeHomeProblem
{
    public interface IUserService
    {
        string GetUsers(DateTime fromDate, DateTime toDate);
    }
}
