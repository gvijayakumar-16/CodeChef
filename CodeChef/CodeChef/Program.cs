using System;
using System.Collections.Generic;

namespace CodeChef
{
    public class Program
    {
        private static readonly string[] _firstMatch = { "Barcelona", "Eibar" };
        private static readonly string[] _secondMatch = { "RealMadrid", "Malaga" };

        public static void Main(string[] args)
        {
            GetUserData();
            if (System.Diagnostics.Debugger.IsAttached) Console.ReadKey();
        }

        private static void GetUserData()
        {
            var numberOfScenarios = Convert.ToInt32(Console.ReadLine());
            if (numberOfScenarios < 1 || numberOfScenarios > 500) throw new ArgumentException();
            var scenarios = new List<Dictionary<string, int>>();
            for (int i = 0; i < numberOfScenarios; i++)
            {
                var matches = new Dictionary<string, int>() { { "Barcelona", 0 }, { "Eibar", 0 }, { "RealMadrid", 0 }, { "Malaga", 0 } };
                for (int j = 0; j < 4; j++)
                {
                    var teamAndScore = Console.ReadLine().Split(' ');
                    var goalsScored = Convert.ToInt32(teamAndScore[1]);
                    if (goalsScored < 0) throw new ArgumentException();
                    matches[teamAndScore[0]] = goalsScored;
                }

                scenarios.Add(matches);
            }
            PrintLaLigaWinners(scenarios);
        }

        private static void PrintLaLigaWinners(IEnumerable<Dictionary<string, int>> scenarios)
        {
            foreach (var scenario in scenarios)
            {
                if (scenario[_secondMatch[0]] >= scenario[_secondMatch[1]])
                {
                    //RealMadrid won the title
                    Console.WriteLine("RealMadrid");
                    continue;
                }
                if (scenario[_firstMatch[0]] > scenario[_firstMatch[1]])
                {
                    //Barcelona won the title
                    Console.WriteLine("Barcelona");
                    continue;
                }
                //Both lost the match and hence RM won the title
                Console.WriteLine("RealMadrid");
            }
        }
    }
}