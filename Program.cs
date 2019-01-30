using System;
using System.Collections;
using System.Linq;

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


            //Prompting a user to input numbers for calculation their sum
            ArrayList numbersList = new ArrayList(); //Declaration of an Array List where numbers will be stored
            string input;

            do
            {
                Console.WriteLine("Print a number and press [Enter] button. If you want to stop - print \"stop\" word:");
                input = Console.ReadLine();
                if (input.All(char.IsDigit))//Checking if user provided a number
                {
                    numbersList.Add(Convert.ToInt32(input));
                }
                else if (input != "stop")//When user provided a symblol - he will be prompted to try again
                {
                    Console.WriteLine("Please provide an integer number, not a symbol. Try again.");
                }

            } while (input != "stop");//At this point the application stops prompting user to input numbers and goes to sum calculation code

            int sum = numbersList.OfType<int>().ToArray().Sum();
            Console.WriteLine($"The sum of numbers provided above is {sum}.");

            Console.WriteLine("Press any key to close the screen...");
            Console.ReadKey();
        }
    }
}
