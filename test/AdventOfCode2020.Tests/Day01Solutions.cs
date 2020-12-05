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
        public void Puzzle1_FindParThatAddsTo2020_AndMultiplyThem()
        {
            var entries = Input.Day01Parse(Input.Day01);

            var expenseReport = new ExpenseReport(entries);

            var result = expenseReport.Find2020PairAndMultiply();

            result.Should().Be(1016131);
        }
    }
}
