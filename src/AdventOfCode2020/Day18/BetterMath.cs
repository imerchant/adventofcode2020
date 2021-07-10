using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day18
{
    public class BetterMath
    {
        private static readonly Regex DigitsAndEitherOperation = new Regex(@"(?'operand1'\d+) (?'operator'[+*]) (?'operand2'\d+)", RegexOptions.Compiled);
        private static readonly Regex DigitsWithAddition = new Regex(@"(?'operand1'\d+) (\+) (?'operand2'\d+)", RegexOptions.Compiled);
        private static readonly Regex DigitsWithMultiplication = new Regex(@"(?'operand1'\d+) (\*) (?'operand2'\d+)", RegexOptions.Compiled);
        private static readonly Regex DigitsInParens = new Regex(@"\((?'digits'\d+)\)", RegexOptions.Compiled);
        private static readonly Regex OnlyDigits = new Regex(@"^\d+$", RegexOptions.Compiled);

        public long CalculateWithoutOperatorPrecedence(string input, out List<string> iterations)
        {
            var count = 0;
            iterations = new();
            while (count++ < 200)
            {
                var builder = new StringBuilder(input);
                iterations.Add(input);

                var digitsInParensMatch = DigitsInParens.Match(input);
                if (digitsInParensMatch.Success)
                {
                    var num = long.Parse(digitsInParensMatch.Groups["digits"].Value);

                    builder.Remove(digitsInParensMatch.Index, digitsInParensMatch.Length);
                    builder.Insert(digitsInParensMatch.Index, $"{num}");

                    input = builder.ToString();
                    continue;
                }

                var digitsAndOperationMatch = DigitsAndEitherOperation.Match(input);
                if (digitsAndOperationMatch.Success)
                {
                    var operand1 = long.Parse(digitsAndOperationMatch.Groups["operand1"].Value);
                    var op = digitsAndOperationMatch.Groups["operator"].Value[0];
                    var operand2 = long.Parse(digitsAndOperationMatch.Groups["operand2"].Value);

                    var result = Operate(operand1, op, operand2);

                    builder.Remove(digitsAndOperationMatch.Index, digitsAndOperationMatch.Length);
                    builder.Insert(digitsAndOperationMatch.Index, $"{result}");

                    input = builder.ToString();
                    continue;
                }

                var onlyDigitsMatch = OnlyDigits.Match(input);
                if (onlyDigitsMatch.Success)
                {
                    var num = long.Parse(input);

                    return num;
                }
            }

            return -1;
        }

        public long CalculateWithNewPrecedence(string input, out List<string> iterations)
        {
            var count = 0;
            iterations = new();
            while (count++ < 200)
            {
                var builder = new StringBuilder(input);
                iterations.Add(input);

                var digitsInParensMatch = DigitsInParens.Match(input);
                if (digitsInParensMatch.Success)
                {
                    var num = long.Parse(digitsInParensMatch.Groups["digits"].Value);

                    builder.Remove(digitsInParensMatch.Index, digitsInParensMatch.Length);
                    builder.Insert(digitsInParensMatch.Index, $"{num}");

                    input = builder.ToString();
                    continue;
                }

                var digitsAdditionMatches = DigitsWithAddition.Matches(input);
                if (digitsAdditionMatches.Any())
                {
                    var digitsAddition = digitsAdditionMatches
                        .OrderByDescending(match => GetPriority(input, match))
                        .First();

                    var operand1 = long.Parse(digitsAddition.Groups["operand1"].Value);
                    var operand2 = long.Parse(digitsAddition.Groups["operand2"].Value);

                    var result = Operate(operand1, '+', operand2);

                    builder.Remove(digitsAddition.Index, digitsAddition.Length);
                    builder.Insert(digitsAddition.Index, $"{result}");

                    input = builder.ToString();
                    continue;
                }

                var digitsMultiplicationMatches = DigitsWithMultiplication.Matches(input);
                if (digitsMultiplicationMatches.Any())
                {
                    var digitsMultiplication = digitsMultiplicationMatches
                        .OrderByDescending(match => GetPriority(input, match))
                        .First();

                    var operand1 = long.Parse(digitsMultiplication.Groups["operand1"].Value);
                    var operand2 = long.Parse(digitsMultiplication.Groups["operand2"].Value);

                    var result = Operate(operand1, '*', operand2);

                    builder.Remove(digitsMultiplication.Index, digitsMultiplication.Length);
                    builder.Insert(digitsMultiplication.Index, $"{result}");

                    input = builder.ToString();
                    continue;
                }

                var onlyDigitsMatch = OnlyDigits.Match(input);
                if (onlyDigitsMatch.Success)
                {
                    var num = long.Parse(input);

                    return num;
                }
            }

            return -1;
        }

        private static long Operate(long left, char op, long right) =>
            op switch
            {
                '+' => left + right,
                '*' => left * right,
                _ => -1
            };

        private static int GetPriority(string input, Match match)
        {
            var priority = 0;
            for (var k = 0; k < match.Index; ++k)
            {
                if (input[k] == '(') priority++;
                if (input[k] == ')') priority--;
            }

            return priority;
        }
    }
}