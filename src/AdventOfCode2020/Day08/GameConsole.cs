using System;
using System.Collections.Generic;
using System.Linq;
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

            static Instruction Parse(Match match, int index)
            {
                var op = match.Groups["op"].Value.ParseEnum<Op>(default);
                var value = int.Parse(match.Groups["value"].Value);
                return new Instruction(index, op, value);
            }
        }

        public void FindSecondInstructionExecution()
        {
            var visited = new HashSet<int>(Instructions.Count);
            for (var k = 0; k < Instructions.Count;)
            {
                var instruction = Instructions[k];
                if (visited.Add(instruction.Index) is false)
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
            }
        }

        public (bool Success, int Accumulator) Run()
        {
            var success = true;
            Accumulator = 0;

            try
            {
                FindSecondInstructionExecution();
            }
            catch (Exception)
            {
                success = false;
            }

            return (success, Accumulator);
        }

        public int AccumulatorAfterFindingInstructionToChange()
        {
            var nopToJmp = RunWithTransforms(Op.nop, Op.jmp);
            if (nopToJmp.Success)
                return nopToJmp.Accumulator;

            var jmpToNop = RunWithTransforms(Op.jmp, Op.nop);
            if (jmpToNop.Success)
                return jmpToNop.Accumulator;

            throw new Exception("could not find a successful run by swapping jmps and nops");

            // execute loop finding after modifying each instruction in turn with the given transform
            (bool Success, int Accumulator) RunWithTransforms(Op targetOp, Op opTransform)
            {
                foreach (var instruction in Instructions.Where(x => x.Op == targetOp))
                {
                    instruction.Op = opTransform;
                    var result = Run();
                    instruction.Op = targetOp;
                    if (result.Success)
                        return result;
                }

                return (false, int.MinValue);
            }
        }
    }
}
