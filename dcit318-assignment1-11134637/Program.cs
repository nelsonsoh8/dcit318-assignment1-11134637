using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dcit318_assignment1_11134637
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //GradeCalculator();
            //TicketPriceCalculator();
            TriangleTypeIdentifier();

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



        // Ticket Price Calculator
        static void TicketPriceCalculator()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Ticket Price Calculator ===");
                Console.Write("\nEnter your age (1-120) or 'Q' to quit: ");

                string input = Console.ReadLine().Trim();

                // Check if user wants to quit
                if (input.Equals("Q", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("\nReturning to main menu...");
                    Thread.Sleep(1000); // Pause for 1 second
                    return;
                }

                // Validate input
                if (!int.TryParse(input, out int age))
                {
                    Console.WriteLine("\nError: Please enter a valid number or 'Q' to quit.");
                    Console.WriteLine("Press any key to try again...");
                    Console.ReadKey();
                    continue;
                }

                // Validate age range
                if (age < 1 || age > 120)
                {
                    Console.WriteLine("\nError: Age must be between 1 and 120.");
                    Console.WriteLine("Press any key to try again...");
                    Console.ReadKey();
                    continue;
                }

                // Calculate price
                decimal price = (age <= 12 || age >= 65) ? 7.00m : 10.00m;

                // Display result
                Console.WriteLine("\n=== Ticket Price ===");
                Console.WriteLine($"Age: {age}");
                Console.WriteLine($"Price: GHC{price:F2}");

                // Show discount information if applicable
                if (age <= 12)
                {
                    Console.WriteLine("(Child discount applied)");
                }
                else if (age >= 65)
                {
                    Console.WriteLine("(Senior discount applied)");
                }

                // Ask to continue
                Console.WriteLine("\nPress any key to calculate another or 'Q' to quit...");
                if (Console.ReadKey().Key == ConsoleKey.Q)
                {
                    return;
                }
            }
        }


        // Triangle Type Identifier
        static void TriangleTypeIdentifier()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Triangle Type Identifier ===");
                Console.WriteLine("\nEnter the lengths of three sides (positive numbers)");
                Console.WriteLine("or 'Q' at any time to quit:");

                double[] sides = new double[3];
                string[] sideNames = { "First", "Second", "Third" };
                bool validInput = true;

                // Get all three sides with validation
                for (int i = 0; i < 3; i++)
                {
                    Console.Write($"{sideNames[i]} side: ");
                    string input = Console.ReadLine().Trim();

                    if (input.Equals("Q", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("\nReturning to main menu...");
                        Thread.Sleep(1000);
                        return;
                    }

                    if (!double.TryParse(input, out sides[i]) || sides[i] <= 0)
                    {
                        Console.WriteLine("\nError: Side must be a positive number.");
                        Console.WriteLine("Press any key to try again...");
                        Console.ReadKey();
                        validInput = false;
                        break;
                    }
                }

                if (!validInput) continue;

                // Check triangle validity using array values
                if (sides[0] + sides[1] <= sides[2] ||
                    sides[0] + sides[2] <= sides[1] ||
                    sides[1] + sides[2] <= sides[0])
                {
                    Console.WriteLine("\nError: These sides cannot form a valid triangle.");
                    Console.WriteLine("The sum of any two sides must be greater than the third side.");
                    Console.WriteLine("Press any key to try again...");
                    Console.ReadKey();
                    continue;
                }

                // Determine triangle type
                string triangleType;
                if (sides[0] == sides[1] && sides[1] == sides[2])
                {
                    triangleType = "Equilateral (all sides equal)";
                }
                else if (sides[0] == sides[1] || sides[0] == sides[2] || sides[1] == sides[2])
                {
                    triangleType = "Isosceles (two sides equal)";
                }
                else
                {
                    triangleType = "Scalene (no sides equal)";
                }

                // Display results
                Console.WriteLine("\n=== Triangle Analysis ===");
                Console.WriteLine($"Side 1: {sides[0]}");
                Console.WriteLine($"Side 2: {sides[1]}");
                Console.WriteLine($"Side 3: {sides[2]}");
                Console.WriteLine($"\nTriangle Type: {triangleType}");

                // Check for right triangle (Pythagorean theorem)
                Array.Sort(sides); // Sort to get largest side last
                if (Math.Abs((sides[0] * sides[0] + sides[1] * sides[1]) - (sides[2] * sides[2])) < 0.0001)
                {
                    Console.WriteLine("Additional Property: Right-angled triangle");
                }

                // Continue or quit
                Console.WriteLine("\nPress any key to analyze another triangle or 'Q' to quit...");
                if (Console.ReadKey().Key == ConsoleKey.Q)
                {
                    return;
                }
            }
        }
    }
}
