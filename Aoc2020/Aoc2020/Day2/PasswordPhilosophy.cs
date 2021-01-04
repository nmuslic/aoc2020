using System.Collections.Generic;
using System.Linq;

namespace Aoc2020.Day2
{
    //https://adventofcode.com/2020/day/2
    public static class PasswordPhilosophy
    {
        public static int GetNumberOfValidPasswordsCounted(string input)
        {
            List<PasswordPolicy> passwordPolicies = ParseInput(input);

            int result = 0;

            foreach (var policy in passwordPolicies)
            {
                int count = policy.Password.Where(x => x == policy.Letter).Count();

                if (count >= policy.MinRequired && count <= policy.MaxRequired)
                {
                    result++;
                }
            }

            return result;
        }

        public static int GetNumberOfValidPasswordsPositioned(string input)
        {
            List<PasswordPolicy> passwordPolicies = ParseInput(input);

            int result = 0;

            foreach (var policy in passwordPolicies)
            {
                char firstPosition = policy.Password[policy.MinRequired - 1];
                char secondPosition = policy.Password[policy.MaxRequired - 1];

                if (firstPosition == policy.Letter ^ secondPosition == policy.Letter)
                {
                    result++;
                }
            }

            return result;
        }

        private static List<PasswordPolicy> ParseInput(string input)
        {
            string[] rows = input.Split('\n')[..^1];

            List<PasswordPolicy> passwordPolicies = new List<PasswordPolicy>();

            foreach (string row in rows)
            {
                string[] passwords = row.Split(' ');

                PasswordPolicy policy = new PasswordPolicy
                {
                    MinRequired = int.Parse(passwords[0].Split('-')[0]),
                    MaxRequired = int.Parse(passwords[0].Split('-')[1]),
                    Letter = passwords[1][0],
                    Password = passwords[2]
                };

                passwordPolicies.Add(policy);
            }

            return passwordPolicies;
        }
    }
}
