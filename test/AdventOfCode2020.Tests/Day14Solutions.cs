using System;
using System.Linq;
using System.Text;
using AdventOfCode2020.Day14;
using AdventOfCode2020.Inputs;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2020.Tests
{
    public class Day14Solutions : TestBase
    {
        public Day14Solutions(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Puzzle1_FindSumOfValues_AfterInstructions()
        {
            var program = new Program(Input.Day14Parse(Input.Day14));

            program.Run();

            program.Memory.Sum(x => x.Value).Should().Be(6631883285184L);
        }

        public const string Puzzle1Example =
@"mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X
mem[8] = 11
mem[7] = 101
mem[8] = 0";

        [Fact]
        public void Puzzle1Example_RunsInstructionsCorrectly()
        {
            var program = new Program(Input.Day14Parse(Puzzle1Example));

            program.Run();

            program.Memory.Sum(x => x.Value).Should().Be(165L);
        }

        [Theory]
        [InlineData("XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X", 11, 73)]
        [InlineData("XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X", 101, 101)]
        [InlineData("XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X", 0, 64)]
        public void ApplicationOfMask_ResultsInCorrectValue(string mask, long originalValue, long expectedValue)
        {
            var asString = Convert.ToString(originalValue, 2).PadLeft(mask.Length, '0');
            var valAsMask = new StringBuilder(asString);

            for (var k = 1; k <= valAsMask.Length; ++k)
            {
                var bit = valAsMask[^k];

                valAsMask[^k] = mask[^k] switch
                {
                    'X' => bit,
                    char c => c
                };
            }

            var finalVal = valAsMask.ToString();
            var actualValueAfterMask = Convert.ToInt64(finalVal, 2);

            actualValueAfterMask.Should().Be(expectedValue);
        }
    }
}
