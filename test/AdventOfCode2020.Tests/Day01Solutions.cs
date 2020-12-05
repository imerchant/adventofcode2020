using AdventOfCode2020.Day01;
using AdventOfCode2020.Inputs;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2020.Tests
{
    public class Day01Solutions : TestBase
    {
        public Day01Solutions(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Puzzle1_FindPairThatAddsTo2020_AndMultiplyThem()
        {
            var entries = Input.Day01Parse(Input.Day01);
            var expenseReport = new ExpenseReport(entries);

            expenseReport.Find2020PairAndMultiply().Should().Be(1016131);
        }

        [Fact]
        public void Puzzle2_FindTripletsThatAddTo2020_AndMultiplyThem()
        {
            var entries = Input.Day01Parse(Input.Day01);
            var expenseReport = new ExpenseReport(entries);

            expenseReport.Find2020TripletAndMultiply().Should().Be(276432018);
        }
    }
}
