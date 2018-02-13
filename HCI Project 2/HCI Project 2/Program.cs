using System;

namespace HCI_Project_2
{
    class Program
    {
        static void Main(string[] args)
        {
            String s;
            int a;

            double pi = 3.14159265358979323846264338;

            Console.WriteLine("Enter how many iterations you want executed (integer): (or q to quit)");

            s = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;

            // Main Loop
            while (s != "q" && s != "quit")
            {
                // Initilize Loop Variables
                int count = 0;
                double ans = pi;


                // Parse input to first integer
                while (!Int32.TryParse(s, out a))
                {
                    Console.WriteLine("Invalid Input: Only enter an Integer Value: ");
                    s = Console.ReadLine();
                }


                // Loop until requested iterations reached
                while (count < a)
                {
                    // Call Compute Function
                    ans = Compute(ans);
                    // Increment counter
                    count++;
                    // Output iteration
                    Console.WriteLine($"Iteration: {count}");
                }

                Console.WriteLine($"Result of Compute = {ans}");

                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("Enter an Integer: (or q to exit)");
                s = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Green;
            }
        }

        static private double Compute(double a)
        {
            double result = 0;
            // Computes Square Root
            result = Math.Sqrt(a);

            return result;
        }

    }
}
