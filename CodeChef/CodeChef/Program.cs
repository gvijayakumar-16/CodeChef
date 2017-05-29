using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChef
{
    public class Program
    {
        private enum Student
        {
            Boy = 0,
            Girl = 1
        }

        public static void Main(string[] args)
        {
            GetUserData();
            //if (System.Diagnostics.Debugger.IsAttached) Console.ReadKey();
        }

        private static void GetUserData()
        {
            var numberOfTestCases = Convert.ToInt32(Console.ReadLine());
            //if (numberOfTestCases < 1 || numberOfTestCases > 10) return; //throw new ArgumentException();
            var students = new List<Student[]>();
            for (int i = 0; i < numberOfTestCases; i++)
            {
                var numberOfStudents = Convert.ToInt64(Console.ReadLine());
                //if (numberOfStudents < 1 || numberOfStudents > Math.Pow(10, 5)) return; //throw new ArgumentException();
                var initialArrangement = Console.ReadLine().Split(' ');
                //if (initialArrangement.Length != numberOfStudents) return; //throw new ArgumentException();
                var formattedArrangement = new Student[numberOfStudents];
                for (int iterator = 0; iterator < numberOfStudents; iterator++)
                {
                    var studentValue = Convert.ToInt32(initialArrangement[iterator]);
                    //if (studentValue < 0 || studentValue > 1) return; //throw new ArgumentException();
                    formattedArrangement[iterator] = (Student)studentValue;
                }
                students.Add(formattedArrangement);
            }
            ProcessStudents(students);
        }

        private static void ProcessStudents(IEnumerable<Student[]> studentsList)
        {
            foreach (var students in studentsList)
            {
                int seconds = 0, iterator = 0;
                var orderedStudents = students.OrderByDescending(x => x);
                //for (int iterator = 0; iterator < students.Length; iterator++)
                while (!Enumerable.SequenceEqual(students, orderedStudents))
                {
                    if (iterator + 1 >= students.Length)
                    {
                        iterator = 0;   //Start the second iteration in the array
                        ++seconds;
                        continue;
                    }
                    if (students[iterator] == students[iterator + 1])
                    {
                        iterator++;
                        //Both are same set of students
                        continue;
                    }
                    if ((int)students[iterator] < (int)students[iterator + 1])
                    {
                        var temp = students[iterator];
                        students[iterator] = students[iterator + 1];
                        students[iterator + 1] = temp;
                        iterator += 2;
                        continue;
                    }
                    iterator++;
                }
                Console.WriteLine(++seconds);
            }
        }
    }
}