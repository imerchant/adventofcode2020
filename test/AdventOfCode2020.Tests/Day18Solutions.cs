using System.Numerics;
using System.Text;
using AdventOfCode2020.Day18;
using AdventOfCode2020.Inputs;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2020.Tests
{
    public class Day18Solutions : TestBase
    {
        private readonly BetterMath _betterMath;

        public Day18Solutions(ITestOutputHelper helper) : base(helper)
        {
            _betterMath = new BetterMath();
        }

        [Fact]
        public void Puzzle2_SumAllInputCalculations_WithSwappedPrecedence()
        {
            var sum = new BigInteger(0);
            foreach (var line in Input.Day18Parse(Input.Day18))
            {
                var result = _betterMath.CalculateWithNewPrecedence(line, out var iterations);
                result.Should().NotBe(-1);
                sum += result;
            }

            sum.Should().Be(224973686321527L);
        }

        [Fact]
        public void Puzzle1_SumAllInputCalculations()
        {
            var sum = new BigInteger(0);
            foreach (var line in Input.Day18Parse(Input.Day18))
            {
                var result = _betterMath.CalculateWithoutOperatorPrecedence(line, out var iterations);
                result.Should().NotBe(-1);
                sum += result;
            }

            sum.Should().Be(1451467526514L);
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
            var result = _betterMath.CalculateWithoutOperatorPrecedence(input, out var iterations);

            foreach (var iteration in iterations)
            {
                Output.WriteLine(iteration);
            }

            result.Should().Be(expectedValue);
        }

        [Fact]
        public void StringBuilder()
        {
            const int index = 0;
            const int length = 5;
            var builder = new StringBuilder("1 + 2 + 3");
            builder.Remove(index, length);
            builder.Insert(0, "3");

            builder.ToString().Should().Be("3 + 3");
        }

        [Theory]
        [InlineData("1 + 2 * 3 + 4 * 5 + 6", 231)]
        [InlineData("1 + (2 * 3) + (4 * (5 + 6))", 51)]
        [InlineData("2 * 3 + (4 * 5)", 46)]
        [InlineData("5 + (8 * 3 + 9 + 3 * 4 * 3)", 1445)]
        [InlineData("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", 669060)]
        [InlineData("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 23340)]
        public void Puzzle2Example_CalculatesCorrectly(string input, int expectedValue)
        {
            var result = _betterMath.CalculateWithNewPrecedence(input, out var iterations);

            foreach (var iteration in iterations)
            {
                Output.WriteLine(iteration);
            }

            result.Should().Be(expectedValue);
        }
    }
}