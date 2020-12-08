using System;
using AdventOfCode2020.Day08;
using AdventOfCode2020.Inputs;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2020.Tests
{
    public class Day08Solutions : TestBase
    {
        public Day08Solutions(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Puzzle1_FindSecondInstructionExecution()
        {
            var console = new GameConsole(Input.Day08);

            Action run = () => console.FindSecondInstructionExecution();

            run.Should().Throw<Exception>().WithMessage("visited instruction[350] (acc +3) with accumulator value 1475");
        }

        public const string Puzzle1Example =
@"nop +0
acc +1
jmp +4
acc +3
jmp -3
acc -99
acc +1
jmp -4
acc +6";

        [Fact]
        public void Puzzle1Example_ConsoleCountsInstructions()
        {
            var console = new GameConsole(Puzzle1Example);

            console.Instructions.Should().HaveCount(9);

            Action run = () => console.FindSecondInstructionExecution();

            run.Should().Throw<Exception>().WithMessage("visited instruction[1] (acc +1) with accumulator value 5");
        }
    }
}
