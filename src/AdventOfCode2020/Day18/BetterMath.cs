using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day18
{
    public class BetterMath
    {
        private static readonly Regex SimpleDigitsAndOp = new Regex(@"(?'operand1'\d+) (?'operator'[+*]) (?'operand2'\d+)", RegexOptions.Compiled);
        private static readonly Regex DigitsInParens = new Regex(@"\((?'digits'\d+)\)", RegexOptions.Compiled);
        private static readonly Regex OnlyDigits = new Regex(@"^\d+$", RegexOptions.Compiled);

        public long Calculate(string input, out List<string> iterations)
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

                var digitsAndOperationMatch = SimpleDigitsAndOp.Match(input);
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

            long Operate(long left, char op, long right) =>
                op switch
                {
                    '+' => left + right,
                    '*' => left * right,
                    _ => -1
                };
        }
    }
}