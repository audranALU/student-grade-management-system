using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentGradeManagementSystem
{
    // Enum to represent grade categories
    enum GradeCategory
    {
        Fail,
        Pass,
        Merit,
        Distinction
    }

    class Program
    {
        static Dictionary<string, int> students = new Dictionary<string, int>();

        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.Clear();

                Console.WriteLine("====================================");
                Console.WriteLine(" STUDENT GRADE MANAGEMENT SYSTEM");
                Console.WriteLine("====================================");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Display All Students");
                Console.WriteLine("3. Search Student");
                Console.WriteLine("4. Calculate Average Grade");
                Console.WriteLine("5. Find Highest and Lowest Grade");
                Console.WriteLine("6. Exit");
                Console.WriteLine("====================================");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudent();
                        break;

                    case "2":
                        DisplayStudents();
                        break;

                    case "3":
                        SearchStudent();
                        break;

                    case "4":
                        CalculateAverage();
                        break;

                    case "5":
                        FindHighestAndLowest();
                        break;

                    case "6":
                        running = false;
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        Pause();
                        break;
                }
            }
        }

        static void AddStudent()
        {
            try
            {
                Console.Write("Enter student name: ");
                string name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new Exception("Student name cannot be empty.");
                }

                Console.Write("Enter student grade (0 - 100): ");

                if (!int.TryParse(Console.ReadLine(), out int grade))
                {
                    throw new Exception("Grade must be a number.");
                }

                if (grade < 0 || grade > 100)
                {
                    throw new Exception("Grade must be between 0 and 100.");
                }

                students[name] = grade;

                Console.WriteLine("Student added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Pause();
        }

        static void DisplayStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No student records found.");
            }
            else
            {
                Console.WriteLine("\nStudent Records:");

                foreach (var student in students)
                {
                    Console.WriteLine(
                        $"Name: {student.Key}, Grade: {student.Value}, Category: {GetGradeCategory(student.Value)}");
                }
            }

            Pause();
        }

        static void SearchStudent()
        {
            Console.Write("Enter student name to search: ");
            string name = Console.ReadLine();

            if (students.ContainsKey(name))
            {
                Console.WriteLine(
                    $"Student: {name} | Grade: {students[name]} | Category: {GetGradeCategory(students[name])}");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }

            Pause();
        }

        static void CalculateAverage()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No grades available.");
            }
            else
            {
                double average = students.Values.Average();
                Console.WriteLine($"Average Grade: {average:F2}");
            }

            Pause();
        }

        static void FindHighestAndLowest()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No grades available.");
            }
            else
            {
                int highest = students.Values.Max();
                int lowest = students.Values.Min();

                Console.WriteLine($"Highest Grade: {highest}");
                Console.WriteLine($"Lowest Grade: {lowest}");
            }

            Pause();
        }

        static GradeCategory GetGradeCategory(int grade)
        {
            if (grade < 50)
                return GradeCategory.Fail;

            if (grade < 70)
                return GradeCategory.Pass;

            if (grade < 85)
                return GradeCategory.Merit;

            return GradeCategory.Distinction;
        }

        static void Pause()
        {
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
    }
}
