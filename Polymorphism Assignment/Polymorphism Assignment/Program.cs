using System;

namespace EmployeeInterfaceApp
{
    // IQuittable interface definition
    // This interface defines a contract that any implementing class must follow
    // Any class that implements this interface must have a Quit() method
    interface IQuittable
    {
        // Method signature for Quit - no implementation in the interface
        void Quit();
    }

    // Employee class that implements the IQuittable interface
    // This means the Employee class MUST implement the Quit() method
    class Employee : IQuittable
    {
        // Property to store the employee's unique identifier
        public int Id { get; set; }

        // Property to store the employee's first name
        public string FirstName { get; set; }

        // Property to store the employee's last name
        public string LastName { get; set; }

        // Implementation of the Quit() method from IQuittable interface
        // This method is called when an employee quits their job
        public void Quit()
        {
            // Display a message indicating the employee has quit
            Console.WriteLine($"{FirstName} {LastName} (ID: {Id}) has quit their job.");
            Console.WriteLine("Processing exit paperwork...");
            Console.WriteLine("Deactivating employee account...");
            Console.WriteLine("Employee successfully removed from active roster.");
        }

        // Overload the "==" operator to compare two Employee objects by their Id
        public static bool operator ==(Employee emp1, Employee emp2)
        {
            // Check if both objects are null
            if (ReferenceEquals(emp1, null) && ReferenceEquals(emp2, null))
            {
                return true;
            }

            // Check if only one object is null
            if (ReferenceEquals(emp1, null) || ReferenceEquals(emp2, null))
            {
                return false;
            }

            // Compare the Id properties
            return emp1.Id == emp2.Id;
        }

        // Overload the "!=" operator (must be overloaded in pairs with "==")
        public static bool operator !=(Employee emp1, Employee emp2)
        {
            return !(emp1 == emp2);
        }

        // Override Equals method for consistency
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Employee))
            {
                return false;
            }
            return this == (Employee)obj;
        }

        // Override GetHashCode method
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }

    // Main Program class
    class Program
    {
        // Entry point of the application
        static void Main(string[] args)
        {
            Console.WriteLine("=== Employee Management System ===\n");

            // Create an Employee object and set its properties
            Employee employee1 = new Employee();
            employee1.Id = 101;
            employee1.FirstName = "John";
            employee1.LastName = "Smith";

            // Display employee information
            Console.WriteLine($"Employee Created: {employee1.FirstName} {employee1.LastName}");
            Console.WriteLine($"Employee ID: {employee1.Id}\n");

            // POLYMORPHISM DEMONSTRATION:
            // Create an object of type IQuittable (interface type)
            // Even though employee1 is an Employee object, we can assign it to an
            // IQuittable variable because Employee implements the IQuittable interface
            // This is polymorphism - treating an object as its interface type
            IQuittable quittableEmployee = employee1;

            Console.WriteLine("--- Employee is quitting ---");

            // Call the Quit() method on the IQuittable interface type
            // This demonstrates polymorphism - we're calling the method through
            // the interface reference, but it executes the Employee class's implementation
            quittableEmployee.Quit();

            Console.WriteLine("\n--- Creating another employee ---");

            // Create a second employee
            Employee employee2 = new Employee()
            {
                Id = 102,
                FirstName = "Sarah",
                LastName = "Johnson"
            };

            Console.WriteLine($"Employee Created: {employee2.FirstName} {employee2.LastName}");
            Console.WriteLine($"Employee ID: {employee2.Id}\n");

            // Polymorphism example 2: Directly assign to IQuittable type during creation
            // This shows we can work with employees through their interface
            IQuittable anotherQuittableEmployee = employee2;

            Console.WriteLine("--- Another employee is quitting ---");
            anotherQuittableEmployee.Quit();

            Console.WriteLine("\n--- Polymorphism Array Example ---");

            // Create an array of IQuittable objects
            // This array can hold any object that implements IQuittable
            IQuittable[] quittableEmployees = new IQuittable[2];

            // Add employees to the array as IQuittable types
            quittableEmployees[0] = new Employee() { Id = 103, FirstName = "Mike", LastName = "Davis" };
            quittableEmployees[1] = new Employee() { Id = 104, FirstName = "Lisa", LastName = "Brown" };

            Console.WriteLine("Processing mass resignation...\n");

            // Loop through the array and call Quit() on each IQuittable object
            // This demonstrates polymorphism - treating different objects uniformly through their interface
            foreach (IQuittable emp in quittableEmployees)
            {
                emp.Quit();
                Console.WriteLine();
            }

            // Wait for user input before closing
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}