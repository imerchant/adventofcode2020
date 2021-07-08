using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day18
{
    public class BetterMath
    {
        private static readonly Regex SimpleDigitsAndOp = new Regex(@"(?'operand1'\d+) (?'operator'[+*]) (?'operand2'\d+)", RegexOptions.Compiled);

        public int Calculate(string input)
        {
            var simpleMatch = SimpleDigitsAndOp.Match(input);
            if (simpleMatch.Success)
            {
                var operand1 = int.Parse(simpleMatch.Groups["operand1"].Value);
                var op = simpleMatch.Groups["operator"].Value[0];
                var operand2 = int.Parse(simpleMatch.Groups["operand2"].Value);

                return Operate(operand1, op, operand2);
            }

            return -1;

            int Operate(int left, char op, int right) =>
                op switch
                {
                    '+' => left + right,
                    '*' => left * right,
                    _ => -1
                };
        }
    }

    public class BetterMath2
    {
        public int Calculate(string input)
        {
            var start = GetNodes(input);

            return start is OperandNode operand
                ? operand.Value
                : -1;
        }

        private static Node GetNodes(string input)
        {
            var startingNode = GetNode(input[0]);
            Node last = startingNode;

            for (var k = 1; k < input.Length; ++k)
            {
                var node = GetNode(input[k]);
                if (node is not null)
                {
                    last.Next = node;
                    last = node;
                }
            }

            return startingNode;

            static Node GetNode(char c) =>
                c switch
                {
                    '(' => new OpenParenNode(),
                    ')' => new CloseParenNode(),
                    '+' => new AddNode(),
                    '*' => new MultiplyNode(),
                    char x when x is >= '0' and <= '9' => new OperandNode(x - '0'),
                    _ => null
                };
        }

        private class OperandNode : Node
        {
            public int Value { get; set; }

            public OperandNode(int value) => Value = value;
        }

        private class OpenParenNode : Node {}

        private class CloseParenNode : Node {}

        private abstract class OperatorNode : Node
        {
            public abstract int Operate(int left, int right);
        }

        private class MultiplyNode : OperatorNode
        {
            public override int Operate(int left, int right) => left * right;
        }

        private class AddNode : OperatorNode
        {
            public override int Operate(int left, int right) => left + right;
        }

        private abstract class Node
        {
            private Node _previous;
            private Node _next;

            public Node Previous
            {
                get => _previous;
                set
                {
                    _previous = value;
                    if (value is not null) _previous._next = this;
                }
            }
            public Node Next
            {
                get => _next;
                set
                {
                    _next = value;
                    if (value is not null) _next._previous = this;
                }
            }
        }
    }
}