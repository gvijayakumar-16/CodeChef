using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChef
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GetUserData();
            if (System.Diagnostics.Debugger.IsAttached) Console.ReadKey();
        }

        private static void GetUserData()
        {
            var numberOfTestCases = Convert.ToInt32(Console.ReadLine());
            if (numberOfTestCases < 1 || numberOfTestCases > 20) throw new ArgumentException();
            var results = new List<string>();
            for (int i = 0; i < numberOfTestCases; i++)
            {
                var activities = Console.ReadLine().ToCharArray();
                if (activities.Length < 1 || activities.Length > Math.Pow(10, 5)) throw new ArgumentException();
                results.Add(activities.IsValidLog() ? "yes" : "no");
            }
            PrintResults(results);
        }

        private static void PrintResults(IEnumerable<string> results)
        {
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
    }

    public static class ProgramExtensions
    {
        public static bool IsValidLog(this char[] activities)
        {
            char previousActivity;
            for (int i = 1; i < activities.Length; i++)
            {
                previousActivity = activities[i - 1];
                switch (activities[i])
                {
                    case 'C':
                        if (previousActivity == 'E' || previousActivity == 'S') return false;
                        break;
                    case 'E':
                        if (previousActivity == 'S') return false;
                        break;
                }
            }
            return true;
        }
    }
}