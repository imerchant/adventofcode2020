using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day08
{
    public class GameConsole
    {
        public static readonly Regex Format = new Regex(@"(?'op'nop|acc|jmp) (?'value'[+-]\d+)", RegexOptions.Compiled);

        public List<Instruction> Instructions { get; }
        public int Accumulator { get; private set; }

        public GameConsole(string input)
        {
            Instructions = Format
                .Matches(input)
                .Select(Parse)
                .ToList();

            static Instruction Parse(Match match)
            {
                var op = match.Groups["op"].Value.ParseEnum<Op>(default);
                var value = int.Parse(match.Groups["value"].Value);
                return new Instruction(op, value);
            }
        }

        public void FindSecondInstructionExecution()
        {
            for (var k = 0; k < Instructions.Count;)
            {
                var instruction = Instructions[k];
                if (instruction.Visited)
                    throw new Exception($"visited instruction[{k}] ({instruction}) with accumulator value {Accumulator}");

                switch (instruction.Op)
                {
                    case Op.acc:
                        Accumulator += instruction.Value;
                        ++k;
                        break;

                    case Op.jmp:
                        k += instruction.Value;
                        break;

                    case Op.nop:
                    default:
                        ++k;
                        break;
                }

                instruction.Visited = true;
            }
        }
    }

    public class Instruction
    {
        public Op Op { get; }
        public int Value { get; }
        public bool Visited { get; set; }

        public Instruction(Op op, int value)
        {
            Op = op;
            Value = value;
        }

        public override string ToString() =>
            new StringBuilder($"{Op:G}")
                .Append(Value < 0 ? " " : " +")
                .Append(Value)
                .ToString();
    }

    public enum Op
    {
        nop,
        acc,
        jmp
    }
}
