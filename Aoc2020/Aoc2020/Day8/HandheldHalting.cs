using System.Collections.Generic;
using System.Linq;

namespace Aoc2020.Day8
{
    public static class HandheldHalting
    {
        private static List<Instruction> instructions;

        public static int GetAccumulatorBeforeInfiniteLoop(string input, HashSet<int> changeCandidates = null)
        {
            instructions = GetInstructionsList(input);

            bool[] visited = new bool[instructions.Count];

            int accumulator = 0;
            int current = 0;

            while (!visited[current])
            {
                visited[current] = true;
                var instruction = instructions[current];

                switch (instruction.Name)
                {
                    case "nop":
                        changeCandidates?.Add(current);
                        current++;
                        break;
                    case "acc":
                        accumulator += instruction.Value;
                        current++;
                        break;
                    case "jmp":
                        changeCandidates?.Add(current);
                        current += instruction.Value;
                        break;
                }
            }

            return accumulator;
        }

        public static int GetAcuumulatorAfterTermination(string input)
        {
            HashSet<int> changeCandidates = new HashSet<int>();

            GetAccumulatorBeforeInfiniteLoop(input, changeCandidates);

            foreach (int candidate in changeCandidates)
            {
                var visited = new int[instructions.Count];
                int accumulator = 0;
                int current = 0;

                while (visited[current] < 2)
                {
                    visited[current]++;
                    string instructionName = instructions[current].Name;

                    if (current == candidate)
                    {
                        instructionName = instructions[current].Name == "nop" ? "jmp" : "nop";
                    }

                    switch (instructionName)
                    {
                        case "nop":
                            current++;
                            break;
                        case "acc":
                            accumulator += instructions[current].Value;
                            current++;
                            break;
                        case "jmp":
                            current += instructions[current].Value == 0 ? 1 : instructions[current].Value;
                            break;
                    }

                    if (instructions.Count == current)
                    {
                        return accumulator;
                    }
                }
            }
            return -1;
        }

        private static List<Instruction> GetInstructionsList(string input) =>
             input.Split('\n')[..^1].Select(x => new Instruction { Name = x.Split(" ")[0], Value = int.Parse(x.Split(" ")[1]) }).ToList();
    }
}