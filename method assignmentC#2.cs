using System;

namespace MathOperationsApp
{
    // This is the main class that contains our math operation method
    class MathOperations
    {
        // This void method takes two integers as parameters
        // It performs a math operation (squaring) on the first integer
        // and displays the second integer to the console
        public void ProcessNumbers(int firstNumber, int secondNumber)
        {
            // Perform a math operation on the first integer (squaring it)
            int result = firstNumber * firstNumber;

            // Display the result of the math operation
            Console.WriteLine($"The square of the first number is: {result}");

            // Display the second integer to the screen
            Console.WriteLine($"The second number is: {secondNumber}");
        }
    }

    // This is the main Program class that contains the entry point of the application
    class Program
    {
        // Main method - this is where the program starts execution
        static void Main(string[] args)
        {
            // Step 2: Instantiate the MathOperations class
            // This creates a new object of the MathOperations class that we can use
            MathOperations mathOps = new MathOperations();

            // Step 3: Call the method, passing in two numbers (5 and 10)
            // This uses positional parameters
            Console.WriteLine("--- First method call (positional parameters) ---");
            mathOps.ProcessNumbers(5, 10);

            // Add a blank line for better readability
            Console.WriteLine();

            // Step 4: Call the method again, this time specifying parameters by name
            // Named parameters allow us to pass arguments in any order
            Console.WriteLine("--- Second method call (named parameters) ---");
            mathOps.ProcessNumbers(firstNumber: 7, secondNumber: 15);

            // Wait for user input before closing the console window
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}