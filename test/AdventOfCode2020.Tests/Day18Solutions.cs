using AdventOfCode2020.Day18;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2020.Tests
{
    public class Day18Solutions : TestBase
    {
        private readonly BetterMath2 _betterMath;

        public Day18Solutions(ITestOutputHelper helper) : base(helper)
        {
            _betterMath = new BetterMath2();
        }

        [Theory]
        [InlineData("1 + 2", 3)]
        [InlineData("1 * 2", 2)]
        [InlineData("1 + 2 * 3", 9)]
        [InlineData("1 + 2 * 3 + 4 * 5 + 6", 71)]
        [InlineData("1 + (2 * 3) + (4 * (5 + 6))", 51)]
        [InlineData("2 * 3 + (4 * 5)", 26)]
        [InlineData("5 + (8 * 3 + 9 + 3 * 4 * 3)", 437)]
        [InlineData("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", 12240)]
        [InlineData("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 13632)]
        public void Puzzle1Examples_CalculateCorrectly(string input, int expectedValue)
        {
            _betterMath.Calculate(input).Should().Be(expectedValue);
        }

        [Fact]
        public void NotInfiniteLoop()
        {
            new BetterMath2().Calculate("1 + 2").Should().Be(1);
        }
    }
}