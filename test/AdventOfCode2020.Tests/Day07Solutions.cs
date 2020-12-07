using AdventOfCode2020.Day07;
using AdventOfCode2020.Inputs;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2020.Tests
{
    public class Day07Solutions : TestBase
    {
        public Day07Solutions(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Puzzle1_CountPossibleParentsOfShinyGoldBag()
        {
            var bags = new Bags(Input.Day07);

            bags.CountShinyGoldParents().Should().Be(278);
        }

        public const string PuzzleExample =
@"light red bags contain 1 bright white bag, 2 muted yellow bags.
dark orange bags contain 3 bright white bags, 4 muted yellow bags.
bright white bags contain 1 shiny gold bag.
muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.
shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.
dark olive bags contain 3 faded blue bags, 4 dotted black bags.
vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.
faded blue bags contain no other bags.
dotted black bags contain no other bags.";

        [Fact]
        public void Bags_Count_AndContainCorrectly()
        {
            var bags = new Bags(PuzzleExample);

            bags.Entries.Should().HaveCount(9);
            bags.CountShinyGoldParents().Should().Be(4);
        }
    }
}
