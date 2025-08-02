using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dcit318_assignment1_11134637
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GradeCalculator();
        }

        // Grade Calculator
        static void GradeCalculator()
        {
            while (true) // Infinite loop until user chooses to quit
            {
                Console.WriteLine("\nGrade Calculator");
                Console.Write("Enter numerical grade (0-100) or 'Q' to quit: ");

                string input = Console.ReadLine();

                // Check if user wants to quit
                if (input.ToUpper() == "Q")
                {
                    break; // Exit the loop
                }

                // Try to parse the input as a grade
                if (!int.TryParse(input, out int grade) || grade < 0 || grade > 100)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 0 and 100 or 'Q' to quit.");
                    continue; // Skip to next iteration
                }

                string letterGrade = grade >= 90 ? "A" :
                                    grade >= 80 ? "B" :
                                    grade >= 70 ? "C" :
                                    grade >= 60 ? "D" : "F";

                Console.WriteLine($"Letter Grade: {letterGrade}");

                // Optional: Add a small pause so user can see the result
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

    }
}
