using System;

namespace ChalDalTakeHomeProblem
{
    public class UserMealDishDto
    {
        public int UserID { get; set; }
        public int DayID { get; set; }
        public DateTime Date { get; set; }
        public int MealID { get; set; }
        public int DishID { get; set; }
    }
}
