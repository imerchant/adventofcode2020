using AdventOfCode2020.Day03;
using AdventOfCode2020.Inputs;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2020.Tests
{
    public class Day03Solutions : TestBase
    {
        public Day03Solutions(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Puzzle1_CountTrees_UsingFirstAngle()
        {
            var slope = new Slope(Input.Day03);

            slope.CountTreesOnDescent(slope.FirstSledAngle).Should().Be(211);
        }

        public const string PuzzleExample = 
@"..##.......
#...#...#..
.#....#..#.
..#.#...#.#
.#...##..#.
..#.##.....
.#.#.#....#
.#........#
#.##...#...
#...##....#
.#..#...#.#";

        [Fact]
        public void PuzzleExample_CountsTreesCorrectly()
        {
            var slope = new Slope(PuzzleExample);

            slope.CountTreesOnDescent(slope.FirstSledAngle).Should().Be(7);
        }
    }
}
