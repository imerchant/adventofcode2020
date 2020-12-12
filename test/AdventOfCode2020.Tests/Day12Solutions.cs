using AdventOfCode2020.Day12;
using AdventOfCode2020.Inputs;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2020.Tests
{
    public class Day12Solutions : TestBase
    {
        public Day12Solutions(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Puzzle1_FollowInstructions_AndFindManhattanDistance()
        {
            var ferry = new Ferry(Input.Day12);

            ferry.FollowInstructions();

            ferry.ManhattanDistance.Should().Be(1645);
        }

        [Fact]
        public void Puzzle2_FollowInstructionsWithWaypoint_AndFindManhattanDistance()
        {
            var ferry = new Ferry(Input.Day12);

            ferry.FollowInstructionsWithWaypoint();

            ferry.ManhattanDistance.Should().Be(35292);
        }

        public const string Example =
@"F10
N3
F7
R90
F11";

        [Fact]
        public void Example_ImportsInstructionsCorrectly()
        {
            var ferry = new Ferry(Example);

            Assert.Collection(ferry.Instructions,
                item => { item.Direction.Should().Be(Direction.F); item.Value.Should().Be(10); },
                item => { item.Direction.Should().Be(Direction.N); item.Value.Should().Be(3); },
                item => { item.Direction.Should().Be(Direction.F); item.Value.Should().Be(7); },
                item => { item.Direction.Should().Be(Direction.R); item.Value.Should().Be(90); },
                item => { item.Direction.Should().Be(Direction.F); item.Value.Should().Be(11); })
                ;
        }

        [Fact]
        public void Ferry_FollowInstructions_WithExample_EndsUpInCorrectPlace()
        {
            var ferry = new Ferry(Example);

            ferry.FollowInstructions();

            (ferry.X, ferry.Y).Should().Be((17, -8));
            ferry.ManhattanDistance.Should().Be(25);
        }

        [Fact]
        public void FerryAndWaypoint_FollowInstructions_WithExample_EndsUpInCorrectPlace()
        {
            var ferry = new Ferry(Example);

            ferry.FollowInstructionsWithWaypoint();

            (ferry.X, ferry.Y).Should().Be((214, -72));
            ferry.ManhattanDistance.Should().Be(286);
        }
    }
}
