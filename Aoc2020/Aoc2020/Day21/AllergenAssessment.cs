using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2020.Day21
{
    public static class AllergenAssessment
    {
        public static int GetNonAllergenCount(string input)
        {
            var lines = input.Split(")\n")[..^1];

            var allergenCandidates = new Dictionary<string, List<string>>();
            var ingredientsDict = new Dictionary<string, int>();
            var usedIngredients = new HashSet<string>();

            foreach (string line in lines)
            {
                var allergens = line.Split(" (contains ")[1].Split(", ");
                var ingredients = line.Split(" (contains ")[0].Split(" ");

                foreach (string allergen in allergens)
                {
                    if (allergenCandidates.ContainsKey(allergen))
                    {
                        allergenCandidates[allergen] = allergenCandidates[allergen].Intersect(ingredients).ToList();
                    }
                    else
                    {
                        allergenCandidates.Add(allergen, ingredients.ToList());
                    }
                }

                foreach (string ingredient in ingredients)
                {
                    if (ingredientsDict.ContainsKey(ingredient))
                    {
                        ingredientsDict[ingredient]++;
                    }
                    else
                    {
                        ingredientsDict.Add(ingredient, 1);
                    }
                }
            }

            while (usedIngredients.Count != allergenCandidates.Count)
            {
                foreach (var candidate in allergenCandidates.Keys)
                {
                    if (allergenCandidates[candidate].Count > 1)
                    {
                        allergenCandidates[candidate] = allergenCandidates[candidate].Except(usedIngredients).ToList();
                    }

                    if (allergenCandidates[candidate].Count == 1)
                    {
                        string ing = allergenCandidates[candidate].First();

                        if(ingredientsDict.ContainsKey(ing))
                        {
                            ingredientsDict.Remove(ing);

                            usedIngredients.Add(ing);

                        }

                    }
                }
            }

            var listResult = String.Join(",", allergenCandidates.OrderBy(x => x.Key).Select(x => x.Value.First()));

            return ingredientsDict.Sum(x => x.Value);
        }

        public static int GetAllergenMaped(string input)
        {
            var lines = input.Split(")\n")[..^1];

            var allergenCandidates = new Dictionary<string, IEnumerable<string>>();
            var ingredientsSet = new HashSet<string>();


            foreach (string line in lines)
            {
                var allergens = line.Split(" (contains ")[1].Split(", ");
                var ingredients = line.Split(" (contains ")[0].Split(" ");

                foreach (string allergen in allergens)
                {
                    if (allergenCandidates.ContainsKey(allergen))
                    {
                        allergenCandidates[allergen] = allergenCandidates[allergen].Intersect(ingredients);
                    }
                    else
                    {
                        allergenCandidates.Add(allergen, ingredients);
                    }
                }

                ingredientsSet.UnionWith(ingredients);
            }

            return ingredientsSet.Count - allergenCandidates.Count;
        }
    }
}