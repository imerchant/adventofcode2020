using System;
using System.Collections.Generic;
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

        [Fact]
        public void Puzzle2_FindSumOfValues_AfterInstructions_UsingV2Masking()
        {
            var program = new ProgramV2(Input.Day14Parse(Input.Day14));

            program.Run();

            program.Memory.Sum(x => x.Value).Should().Be(3161838538691L);
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

        public const string Puzzle2Example =
@"mask = 000000000000000000000000000000X1001X
mem[42] = 100
mask = 00000000000000000000000000000000X0XX
mem[26] = 1";

        [Fact]
        public void Puzzle2Example_RunsInstructionsCorrectly()
        {
            var program = new ProgramV2(Input.Day14Parse(Puzzle2Example));

            program.Run();

            program.Memory.Sum(x => x.Value).Should().Be(208L);
        }

        public static IEnumerable<object[]> ApplicationOfV2MaskCases()
        {
            yield return new object[] { "000000000000000000000000000000X1001X", 42L, new List<long> { 26, 27, 58, 59 } };
            yield return new object[] { "00000000000000000000000000000000X0XX", 26L, new List<long> { 16, 17, 18, 19, 24, 25, 26, 27 } };
        }

        [Theory]
        [MemberData(nameof(ApplicationOfV2MaskCases))]
        public void ApplicationsOfV2Mask_ResultsInCorrectLocations(string mask, long originalLocation, List<long> expectedLocations)
        {
            var locationAsString = Convert.ToString(originalLocation, 2).PadLeft(mask.Length, '0');
            var locationAsMask = new StringBuilder(locationAsString);

            for (var k = 1; k <= locationAsMask.Length; ++k)
            {
                var bit = locationAsMask[^k];

                locationAsMask[^k] = mask[^k] switch
                {
                    'X' => 'X',
                    '1' => '1',
                    _ => bit
                };
            }

            var locationMasks = new HashSet<string>();
            var stack = new Stack<string>();
            stack.Push(locationAsMask.ToString());

            do
            {
                var locationMask = stack.Pop();
                var firstX = locationMask.IndexOf('X');
                if (firstX >= 0)
                {
                    var builder = new StringBuilder(locationMask);
                    builder[firstX] = '1';
                    stack.Push(builder.ToString());

                    builder[firstX] = '0';
                    stack.Push(builder.ToString());
                    continue;
                }

                locationMasks.Add(locationMask);
            } while (stack.TryPeek(out _));

            var locations = locationMasks.Select(x => Convert.ToInt64(x, 2));

            locations.Should().BeEquivalentTo(expectedLocations);
        }
    }
}
