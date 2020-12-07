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
        public void Puzzle1And2_CountPossibleParentsOfShinyGoldBag_AndItsChildren()
        {
            var bags = new Bags(Input.Day07);

            bags.CountShinyGoldParents().Should().Be(278);
            bags.CountShinyGoldChildren().Should().Be(45157);
        }

        public const string Puzzle1Example =
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
            var bags = new Bags(Puzzle1Example);

            bags.Entries.Should().HaveCount(9);
            bags.CountShinyGoldParents().Should().Be(4);
        }

        public const string Puzzle2Example =
@"shiny gold bags contain 2 dark red bags.
dark red bags contain 2 dark orange bags.
dark orange bags contain 2 dark yellow bags.
dark yellow bags contain 2 dark green bags.
dark green bags contain 2 dark blue bags.
dark blue bags contain 2 dark violet bags.
dark violet bags contain no other bags.";

        [Fact]
        public void Puzzle2Example_CountsShinyGoldChildrenCorrectly()
        {
            var bags = new Bags(Puzzle2Example);

            (bags[Bags.ShinyGold].CountChildren() - 1).Should().Be(126);
        }
    }
}
