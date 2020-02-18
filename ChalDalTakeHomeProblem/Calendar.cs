using System;
using System.Collections.Generic;

namespace ChalDalTakeHomeProblem
{
    public class CalendarData
    {
        public Calendar Calendar { get; set; }
    }
    public class Calendar
    {
        public IDictionary<DateTime, int> DateToDayId { get; set; }
        public IDictionary<int, int> dishIdToMealId { get; set; }
        public IDictionary<int, int> mealIdToDayId { get; set; }
    }
}
