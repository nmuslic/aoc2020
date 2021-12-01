using System.Collections.Generic;
using System.Linq;

namespace Aoc2020.Day18
{
    public static class OperationOrder
    {
        public static long GetExpressionSum(string input)
        {
            var lines = input.Split("\r\n");

            return lines.Sum(x => EvaluateExpression(x.Split(' ')));
        }
        private static long EvaluateExpression(string[] expression)
        {
            var stack = new Stack<string>();

            foreach (string exp in expression)
            {
                if (stack.Count == 0 && long.TryParse(exp, out long _))
                {
                    stack.Push(exp);
                }
                else if (exp == "+" || exp == "*")
                {
                    stack.Push(exp);
                }
                else if (long.TryParse(exp, out long second))
                {
                    string operation = stack.Pop();
                    var test = stack.Peek();
                    long first = long.Parse(stack.Pop());

                    stack.Push(operation == "+" ? $"{first + second}" : $"{first * second}");
                }
                else
                {
                    if (exp.StartsWith("("))
                    {
                        var temp = exp;
                        while(temp.StartsWith("("))
                        {
                            stack.Push("(");
                            temp = temp[1..];
                        }

                        stack.Push(temp);
                    }
                    else
                    {
                        long count = exp.Count(x => x == ')');
                        second = long.Parse(exp.Split(')')[0]);
                        string operation = stack.Pop();
                        while (count > 0)
                        {
                            if (stack.Peek() == "(")
                            {
                                stack.Pop();
                                count--;
                            }
                            else
                            {
                                long first = long.Parse(stack.Pop());

                                second = operation == "+" ? first + second : first * second;
                            }

                            if (count > 0 && stack.Peek() != "(")
                            {
                                operation = stack.Pop();
                            }
                        }

                        if (stack.Count > 0 && stack.Peek() != "(")
                        {
                            operation = stack.Pop();
                            long first = long.Parse(stack.Pop());
                            stack.Push(operation == "+" ? $"{first + second}" : $"{first * second}");
                        }
                        else
                        {
                            stack.Push($"{second}");
                        }
                    }
                }
            }

            return long.Parse(stack.Pop());
        }
    }
}
