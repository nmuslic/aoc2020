using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2020.Day7
{
    public class HandyHaversacks
    {
        public static int GetNumberOfBags(string input)
        {
            string[] lines = input.Split('\n')[..^1].ToArray();
            Dictionary<string, string[]> bags = lines.ToDictionary(x => string.Join(" ", x.Split(" ").Take(2)),
                                                       x => x.Split("contain")[1].Split(",").Select(x => string.Join(" ", x.Split(" ").Skip(2).Take(2))).ToArray());

            return bags.Keys.Count(x => IsBagValid(x, x, bags));
        }

        public static bool IsBagValid(string mainBag, string currentBag, Dictionary<string, string[]> bags)
        {
            if (currentBag == "shiny gold")
            {
                return true;
            }
            else if (currentBag == "other bags.")
            {
                return false;
            }

            return bags[currentBag].Where(x => IsBagValid(mainBag, x, bags)).Any();
        }

        public static int GetRequiredBags(string input)
        {
            string[] lines = input.Split('\n')[..^1].ToArray();

            Dictionary<string, List<Tuple<string, string>>> weightedBags = lines.ToDictionary(x =>
                                string.Join(" ", x.Split(" ").Take(2)),
                                x => x.Split("contain")[1].Split(",")
                                .Select(x => new Tuple<string, string>(x.Split(" ").Skip(1).First(), string.Join(" ", x.Split(" ").Skip(2).Take(2)))).ToList());

            int result = weightedBags["shiny gold"].Sum(x => GetBagSum(x.Item2, x.Item1, weightedBags));

            return result;
        }

        public static int GetBagSum(string bag, string weight, Dictionary<string, List<Tuple<string, string>>> weightedBags)
        {
            if (weight == "no")
            {
                return 0;
            }

            return weightedBags[bag].Sum(x => GetBagSum(x.Item2, x.Item1, weightedBags)) * int.Parse(weight) + int.Parse(weight);
        }
    }
}