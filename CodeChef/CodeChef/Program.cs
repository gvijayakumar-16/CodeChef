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
            if (numberOfTestCases < 1 || numberOfTestCases > 200) throw new ArgumentException();
            var results = new List<string>();
            var matchingIngredients = 0;
            for (int i = 0; i < numberOfTestCases; i++)
            {
                var firstDishIngredients = Console.ReadLine().Split(' ');
                var secondDishIngredients = Console.ReadLine().Split(' ');
                foreach (var ingredient in firstDishIngredients)
                {
                    foreach (var ingredient2 in secondDishIngredients)
                    {
                        if (ingredient.IsValid() || ingredient2.IsValid()) throw new ArgumentException();
                        if (matchingIngredients >= 2) break;
                        if (string.Equals(ingredient, ingredient2)) ++matchingIngredients;
                    }
                    if (matchingIngredients >= 2)
                    {
                        break;
                    }
                }
                if (matchingIngredients >= 2)
                    results.Add("similar");
                else
                    results.Add("dissimilar");
                matchingIngredients = 0;
            }
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
    }

    public static class ProgramExtensions
    {
        public static bool IsValid(this string ingredient)
        {
            return ingredient.Length < 2 || ingredient.Length > 10;
        }
    }
}