using System;

namespace ChalDalTakeHomeProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataLoader dataLoader = new DataLoader();
            var testData = dataLoader.LoadData();
            Console.WriteLine("Hello World!");
        }
    }
}
