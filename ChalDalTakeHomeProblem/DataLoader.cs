using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ChalDalTakeHomeProblem
{
    public interface IDataLoader
    {
        List<UserMealDishDto>LoadData();
    }
    public class DataLoader : IDataLoader
    {
        private const string DATA_PATH= @"D:\Projects\chaldal-assignment\data";
        public List<UserMealDishDto> LoadData()
        {
            var userMealList = new List<UserMealDishDto>();
            foreach(var filePath in Directory.GetFiles(DATA_PATH).Where(f=>f.EndsWith(".json")))
            {
                var userId = Path.GetFileNameWithoutExtension(filePath);
                var calenDarObject = JsonConvert.DeserializeObject<CalendarData>(File.ReadAllText(filePath, Encoding.UTF8));
                var dateWiseMeals = from dateId in calenDarObject.Calendar.DateToDayId
                                    join mealDay in calenDarObject.Calendar.mealIdToDayId on dateId.Value equals mealDay.Value
                                    select new UserMealDishDto { UserID = Convert.ToInt32(userId), Date = dateId.Key, DayID = dateId.Value, MealID = mealDay.Key };
                userMealList.AddRange(dateWiseMeals);
            }
            return userMealList;
        }
    }
}
