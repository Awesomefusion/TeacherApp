using System;

namespace TeacherApp
{
    public class Program
    {
        public static void Main()
        {
            int minStudents = 6;

            Console.Write("Greetings teacher, please input number of students: ");
            Console.WriteLine(" ");

            int studentsInput = int.Parse(Console.ReadLine());

            if (studentsInput >= minStudents)
            {
                Console.WriteLine("Number of students acceptable, thank you.");
            }
            else
            {
                Console.WriteLine("Please input a number of students of 6 or more.");
                return;
            }
            List<Student> students = new List<Student>();
            Console.WriteLine(" ");

            Console.WriteLine("Please enter Student Names and Scores.");

            for (int i = 0; i < studentsInput; i++)
            {
                Student student = new Student();

                Console.Write("Enter Student Name: ");
                student.Name = Console.ReadLine();

                Console.WriteLine(" ");

                Console.Write("Enter Student Score: ");
                student.Score = int.Parse(Console.ReadLine());

                students.Add(student);
            }

            if (students.Count == studentsInput)
            {
                Console.WriteLine("Students list matches with initial inputted amount of students.");
            }
            else
            {
                Console.WriteLine("Students list doesn't match with initial inputted amount of students, please make sure you input data for each number of students selected.");
                return;
            }

            foreach (var student in students)
            {
                if (student.Score < 40)
                {
                    student.Grade = "Fail";
                }
                else if (student.Score >= 40)
                {
                    if (student.Score <= 50)
                    {
                        student.Grade = "Pass";
                    }
                        else if (student.Score >= 51)
                        {
                            if (student.Score <= 69)
                            {
                                student.Grade = "Merit";
                            }
                                else if (student.Score >= 70)
                                {
                                    if (student.Score <= 100)
                                    {
                                        student.Grade = "Distinction";
                                    }
                                }
                        }
                }
            }

            List<Student> SortedList = students.OrderByDescending(o=>o.Grade).ToList();

            using (StreamWriter sw = new StreamWriter("results.txt"))
            {
                foreach (var student in SortedList)
                {
                    sw.WriteLine(string.Format("Name: {0} Score: {1} Grade: {2}", student.Name, student.Score.ToString(), student.Grade));
                }
            }

            Console.WriteLine("Thank you! All data is shown in the file results.txt");

        }
    }
}