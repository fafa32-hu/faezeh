using System;
using System.Data.Entity;
using System.Linq;

namespace StudentDatabaseApp
{
    // Student Model Class
    // This represents a table in the database
    // Each property becomes a column in the Student table
    public class Student
    {
        // Primary Key - Entity Framework recognizes "Id" as the primary key by convention
        public int Id { get; set; }

        // Student's first name
        public string FirstName { get; set; }

        // Student's last name
        public string LastName { get; set; }

        // Student's enrollment date
        public DateTime EnrollmentDate { get; set; }
    }

    // DbContext Class
    // This class manages the database connection and provides access to the database
    // It inherits from DbContext which is part of Entity Framework
    public class SchoolContext : DbContext
    {
        // DbSet represents a table in the database
        // This creates a "Students" table in the database
        public DbSet<Student> Students { get; set; }
    }

    // Main Program Class
    class Program
    {
        // Entry point of the application
        static void Main(string[] args)
        {
            // Create an instance of the SchoolContext
            // The 'using' statement ensures the database connection is properly closed
            using (var context = new SchoolContext())
            {
                // Display a message indicating the database is being created
                Console.WriteLine("Creating database and adding a student...\n");

                // Create a new Student object with sample data
                var student = new Student
                {
                    FirstName = "John",
                    LastName = "Doe",
                    EnrollmentDate = DateTime.Now
                };

                // Add the student to the Students DbSet
                // This stages the student to be added to the database
                context.Students.Add(student);

                // SaveChanges() commits all changes to the database
                // This is when the INSERT statement is actually executed
                // The database and table are created automatically if they don't exist
                context.SaveChanges();

                // Confirmation message
                Console.WriteLine("✓ Student added to database successfully!\n");

                // Display the student information
                Console.WriteLine("--- Student Information ---");
                Console.WriteLine($"Student ID: {student.Id}");
                Console.WriteLine($"Name: {student.FirstName} {student.LastName}");
                Console.WriteLine($"Enrollment Date: {student.EnrollmentDate.ToShortDateString()}");
                Console.WriteLine();

                // Retrieve and display all students from the database
                Console.WriteLine("--- All Students in Database ---");
                var allStudents = context.Students.ToList();

                // Loop through each student and display their information
                foreach (var s in allStudents)
                {
                    Console.WriteLine($"ID: {s.Id}, Name: {s.FirstName} {s.LastName}, Enrolled: {s.EnrollmentDate.ToShortDateString()}");
                }
            }

            // Wait for user input before closing
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}