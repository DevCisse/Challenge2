using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenge2
{
    class Program
    {
        static void Main(string[] args)
        {

            #region challenge 2
            int noOfStudents = default;
            Console.WriteLine("Enter number of students");

          
            //UNDONE: we can check for valid input
            noOfStudents = Convert.ToInt32(Console.ReadLine());


            List<Student> students = new List<Student>(noOfStudents);


            for (int i = 0; i < noOfStudents; i++)
            {
                //TODO: Add humanizer to make display  messge nicely
                Console.WriteLine($"Enter {(i + 1).ToOrdinalWords()} student's first name");
                var fName = Console.ReadLine();

                Console.WriteLine($"Enter {(i + 1).ToOrdinalWords()} student's last name");
                var lName = Console.ReadLine();


                Console.WriteLine("Enter number of test ");

                int noOfTest = Convert.ToInt32(Console.ReadLine());
                Student student = new Student
                {
                    FirstName = fName,
                    LastName = lName,
                    NoOfTest = noOfStudents
                };

                for (int j = 0; j < noOfTest; j++)
                {
                    Console.WriteLine($"Enter {(j + 1).ToOrdinalWords()} test score");
                    int testScore = Convert.ToInt32(Console.ReadLine());

                    student.StudentTests.Add(new StudentTest(testScore));
                }

                students.Add(student);

            }

            foreach (var stud in students)
            {

                Console.WriteLine($"{stud.FirstName} {stud.LastName}");
                Console.WriteLine($"Average {stud.Average()}");

                foreach (var item in stud.StudentTests)
                {
                    Console.WriteLine($"{item.Score } {item.Grade}");
                }
            }




            #endregion
        }
    }


    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int NoOfTest { get; set; }

        public List<StudentTest> StudentTests { get; set; } = new List<StudentTest>();


        public double Average()
        {
            return StudentTests.Sum(x => x.Score) / StudentTests.Count;
        }
    }


    public class StudentTest
    {


        private int score;
        private char grade;



        public StudentTest(int score)
        {
            // this.score = score;
            Score = score;

        }


        public int Score
        {
            get => score;

            set
            {
                score = value;

                switch (score)
                {
                    case >= 90:
                        grade = 'A';
                        break;
                    case >= 80:
                        grade = 'B';
                        break;
                    case >= 70:
                        grade = 'C';
                        break;
                    case >= 60:
                        grade = 'D';
                        break;
                    default:
                        grade = 'F';
                        break;
                }
            }


        }
        public char Grade { get => grade; private set { grade = value; } }


    }
}
