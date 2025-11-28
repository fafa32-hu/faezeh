using System;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;

namespace EmployeeComparisonApp
{
    // Employee class with properties and overloaded comparison operators
    class Employee
    {
        // Property to store the employee's unique identifier
        public int Id { get; set; }

        // Property to store the employee's first name
        public string FirstName { get; set; }

        // Property to store the employee's last name
        public string LastName { get; set; }

        // Overload the "==" operator to compare two Employee objects by their Id
        // This operator checks if two employees are equal based on their Id property
        public static bool operator ==(Employee emp1, Employee emp2)
        {
            // Check if both objects are null (they are equal if both are null)
            if (ReferenceEquals(emp1, null) && ReferenceEquals(emp2, null))
            {
                return true;
            }

            // Check if only one object is null (they are not equal)
            if (ReferenceEquals(emp1, null) || ReferenceEquals(emp2, null))
            {
                return false;
            }

            // Compare the Id properties of both Employee objects
            return emp1.Id == emp2.Id;
        }

        // Overload the "!=" operator (must be overloaded in pairs with "==")
        // This operator checks if two employees are NOT equal based on their Id
        public static bool operator !=(Employee emp1, Employee emp2)
        {
            // Return the opposite of the "==" operator result
            return !(emp1 == emp2);
        }

        // Override Equals method for consistency with operator overloading
        // This is a best practice when overloading == and !=
        public override bool Equals(object obj)
        {
            // Check if the object is null or not an Employee
            if (obj == null || !(obj is Employee))
            {
                return false;
            }

            // Cast the object to Employee and compare using the == operator
            return this == (Employee)obj;
        }

        // Override GetHashCode method (required when overriding Equals)
        // This ensures the object can be used properly in hash-based collections
        public override int GetHashCode()
        {
            // Return the hash code of the Id property
            return Id.GetHashCode();
        }
    }

    // Main Program class
    class Program
    {
        // Entry point of the application
        static void Main(string[] args)
        {
            // Create the first Employee object
            Employee employee1 = new Employee();
            employee1.Id = 1;
            employee1.FirstName = "John";
            employee1.LastName = "Smith";

            // Create the second Employee object with the same Id
            Employee employee2 = new Employee();
            employee2.Id = 1;
            employee2.FirstName = "Jane";
            employee2.LastName = "Doe";

            // Create the third Employee object with a different Id
            Employee employee3 = new Employee();
            employee3.Id = 2;
            employee3.FirstName = "Bob";
            employee3.LastName = "Johnson";

            // Display information about each employee
            Console.WriteLine("Employee 1: Id={0}, Name={1} {2}",
                employee1.Id, employee1.FirstName, employee1.LastName);
            Console.WriteLine("Employee 2: Id={0}, Name={1} {2}",
                employee2.Id, employee2.FirstName, employee2.LastName);
            Console.WriteLine("Employee 3: Id={0}, Name={1} {2}",
                employee3.Id, employee3.FirstName, employee3.LastName);
            Console.WriteLine();

            // Compare employee1 and employee2 using the overloaded "==" operator
            // These should be equal because they have the same Id (1)
            if (employee1 == employee2)
            {
                Console.WriteLine("Employee 1 and Employee 2 are EQUAL (same Id)");
            }
            else
            {
                Console.WriteLine("Employee 1 and Employee 2 are NOT equal");
            }

            // Compare employee1 and employee3 using the overloaded "==" operator
            // These should NOT be equal because they have different Ids (1 vs 2)
            if (employee1 == employee3)
            {
                Console.WriteLine("Employee 1 and Employee 3 are equal");
            }
            else
            {
                Console.WriteLine("Employee 1 and Employee 3 are NOT EQUAL (different Ids)");
            }

            Console.WriteLine();

            // Demonstrate the "!=" operator
            // Check if employee2 and employee3 are not equal
            if (employee2 != employee3)
            {
                Console.WriteLine("Employee 2 and Employee 3 are NOT EQUAL (using != operator)");
            }
            else
            {
                Console.WriteLine("Employee 2 and Employee 3 are equal");
            }

            // Check if employee1 and employee2 are not equal
            if (employee1 != employee2)
            {
                Console.WriteLine("Employee 1 and Employee 2 are not equal");
            }
            else
            {
                Console.WriteLine("Employee 1 and Employee 2 are EQUAL (using != operator)");
            }

            // Wait for user input before closing the console window
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}