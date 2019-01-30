using System;

namespace Exercise1
{
    class Program
    {
        static void Main()
        {
            //Current date calculation and printing
            var date = DateTime.Now;
            Console.WriteLine($"The current date in the \"yyyy/mm/dd\" format is: {date.ToString("yyyy/MM/dd")};");

            //Number of days elapsed since start of the year calculation and printing
            Console.WriteLine($"Sinse the start fo the current year elapsed {date.DayOfYear} days;");

            //Calculation and printing the next leap year that starts with a Tuesday
            bool isLeapYear;
            var leapYearSearch = date;
            do
            {

                leapYearSearch = new DateTime((leapYearSearch.Year + 1), 1, 1);
                isLeapYear = DateTime.IsLeapYear(leapYearSearch.Year);

            } while (!isLeapYear || leapYearSearch.DayOfWeek.ToString() != "Tuesday");
            Console.WriteLine($"The next leap year that starts with a Tuesday is {leapYearSearch.Year};");
            
            Console.ReadKey();
        }
    }
}
