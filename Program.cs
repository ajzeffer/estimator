using System;
using estimator.models;

namespace estimator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Estimating ...");
            var parsedTime =  int.TryParse(args[0],out int result);
            var parsedIncrement = Enum.TryParse(args[1], true, out TimeIncrement timeIncrement);
            if(!parsedTime || !parsedIncrement){
                Console.WriteLine("I was unable to parse your command.");
                Console.WriteLine("Please format your args accordingly estimate {1} {days, weeks, months}");
                return;
            }
            var effort = Effort.Create(timeIncrement, result);
            Console.WriteLine($"Your Tshirt Size Estimate is: {effort.TshirtSize.TshirtSizeEnum.ToString()} (days: {effort.Days}, weeks: {effort.Weeks}, months: {effort.Months}");
        }
    }
}
