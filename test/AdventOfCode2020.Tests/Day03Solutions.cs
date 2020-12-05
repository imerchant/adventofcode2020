using System.Collections.Generic;
using System.Linq;
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

            slope.CountTreesOnDescent(Slope.FirstSledAngle).Should().Be(211);
        }

        [Fact]
        public void Puzzle1_CountTrees_OnAllAngles()
        {
            var slope = new Slope(Input.Day03);

            slope.MultiplyTreesOnAllAngles().Should().Be(3584591857L);
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

            slope.CountTreesOnDescent(Slope.FirstSledAngle).Should().Be(7);
        }

        [Fact]
        public void PuzzleExample_AggregatesAllAngles()
        {
            var expectedResults = new List<int> { 2, 7, 3, 4, 2 };
            var slope = new Slope(PuzzleExample);

            var results = Slope.AllAngles.Select(slope.CountTreesOnDescent).ToList();

            results.Should().BeEquivalentTo(expectedResults);
            results.Aggregate(1L, (state, item) => state * item).Should().Be(336);
        }

        [Fact]
        public void PuzzleExample_UsingMultiplyTreesOnAllAngles_CalculatesCorrectly()
        {
            var slope = new Slope(PuzzleExample);

            slope.MultiplyTreesOnAllAngles().Should().Be(336);
        }
    }
}
