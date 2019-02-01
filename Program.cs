using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Exercise1
{
    static class Program
    {
        // Method which checks and prints that provided by user email address is a valid email
        static void EmailAddress()
        {
            string emailAddress;
            Console.WriteLine("Please input an email address and press [Enter] button on your keyboard:");
            emailAddress = Console.ReadLine();
            if (Regex.IsMatch(emailAddress, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            {
                Console.WriteLine("Provided above email is a valid email address.");
            }
            else
            {
                Console.WriteLine("Unfortunately provided email is not a valid email address.");
            }
        }
        // Method which calculates and prints to console current date, number of days elapsed since start of the year and the next leap year that starts with a Tuesday
        static void DaysAndYears()
        {
            // Current date calculation and printing
            var date = DateTime.Now;
            var newYear = new DateTime(date.Year, 1, 1, 0, 0, 0); // Current year starting date and time declaration
            TimeSpan timeElapsed = date.Subtract(newYear); // Get the TimeSpan of the difference between now and start of the year
            double daysAgo = timeElapsed.TotalDays;
            Console.WriteLine($"The current date in the \"yyyy/mm/dd\" format is: {date.ToString("yyyy/MM/dd")};");

            // Number of days elapsed since start of the year calculation and printing
            Console.WriteLine($"Sinse the start of the current year elapsed {daysAgo.ToString("0")} full days;");

            // Calculation and printing the next leap year that starts with a Tuesday
            bool isLeapYear;
            var leapYearSearch = date;
            do
            {

                leapYearSearch = new DateTime(leapYearSearch.Year + 1, 1, 1);
                isLeapYear = DateTime.IsLeapYear(leapYearSearch.Year);

            } while (!isLeapYear || leapYearSearch.DayOfWeek != DayOfWeek.Tuesday);
            Console.WriteLine($"The next leap year that starts with a Tuesday is {leapYearSearch.Year};");
        }

        // Method which calculates and prints the sum of the sequence of numbers provided by the user
        static void SumOfSequenceOfNumbers()
        {
            // Prompting a user to input numbers for calculation their sum
            var numbersList = new List<int>(); // Declaration of an integer List where numbers will be stored
            string input;

            do
            {
                Console.WriteLine("Print a number and press [Enter] button. If you want to stop - print \"stop\" word:");
                input = Console.ReadLine();
                if (input.All(char.IsDigit)) // Checking if user provided a number
                {
                    try
                    {
                        numbersList.Add(Convert.ToInt32(input));
                    }
                    catch
                    {
                        Console.WriteLine("Please provide an integer numbers only, not any other kinds of numbers or symbols. Try again.");
                    }

                }
                else if (input != "stop") // When user provided a symblol - he will be prompted to try again
                {
                    Console.WriteLine("Please provide an integer numbers only, not any other kinds of numbers or symbols. Try again.");
                }

            } while (input != "stop"); // At this point the application stops prompting user to input numbers and goes to sum calculation code

            int sum = numbersList.Sum();
            Console.WriteLine($"The sum of numbers provided above is {sum}.");
        }
        static void Main()
        {
            // Calling program methods
            DaysAndYears();
            EmailAddress();
            SumOfSequenceOfNumbers();

            // Screen closing dialogue
            Console.WriteLine("Press any key to close the screen...");
            Console.ReadKey();
        }
    }
}
