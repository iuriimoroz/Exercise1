using System;

namespace Exercise1
{
    static class Program
    {
        //Method which checks the validity of email string provided
        static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
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

            //Checking if provided by user email address is a valid email
            string emailAddress;
            Console.WriteLine("Please input an email address and press [Enter] button on your keyboard:");
            emailAddress = Console.ReadLine();
            if(IsValidEmail(emailAddress))
            {
                Console.WriteLine("Provided above email is a valid email address.");
            }
            else
            {
                Console.WriteLine("Unfortunately provided email is not a valid email address.");
            }
            
            Console.ReadKey();
        }
    }
}
