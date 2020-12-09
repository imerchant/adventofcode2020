using System.Collections.Generic;
using System.Linq;
using AdventOfCode2020.Day09;
using AdventOfCode2020.Inputs;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2020.Tests
{
    public class Day09Solutions : TestBase
    {
        public Day09Solutions(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Puzzle1_FindFirstInvalid()
        {
            const int preambleLength = 25;
            var system = new XmasSystem(Input.Day09);

            system.FindFirstInvalid(preambleLength).Should().Be(138879426L);
        }

        [Fact]
        public void Puzzle2_FundSumOfMinAndMaxOfSetThatAddsToInvalid()
        {
            const long firstInvalid = 138879426L;
            var system = new XmasSystem(Input.Day09);

            var set = system.FindSetThatAddsToInvalid(firstInvalid);

            var (min, max) = (set.Min(), set.Max());

            (min + max).Should().Be(23761694L);
        }


        public const string PuzzleExample =
@"35
20
15
25
47
40
62
55
65
95
102
117
150
182
127
219
299
277
309
576";

        [Fact]
        public void PuzzleExample_FindFirstInvalid()
        {
            const int preambleLength = 5;
            var system = new XmasSystem(PuzzleExample);

            system.FindFirstInvalid(preambleLength).Should().Be(127);
        }

        [Fact]
        public void PuzzleExample_FindSetThatAddsToInvalid()
        {
            var expectedSet = new List<long> { 15, 25, 47, 40 };
            var system = new XmasSystem(PuzzleExample);

            var actual = system.FindSetThatAddsToInvalid(127);

            actual.Should().BeEquivalentTo(expectedSet);

            var (min, max) = (actual.Min(), actual.Max());

            (min + max).Should().Be(62);
        }
    }
}
