using System.Collections.Generic;
using System.Linq;
using AdventOfCode2020.Day15;
using AdventOfCode2020.Inputs;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2020.Tests
{
    public class Day15Solutions : TestBase
    {
        public Day15Solutions(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Puzzle1_NumberGame_Find2020thNumber()
        {
            var game = new NumberGame(Input.Day15);

            do
            {
                game.Turn();
            } while (game.Numbers.Count < 2020);

            game.Numbers.Last().Should().Be(496);
        }

        [Fact(Skip = "Takes ~3 seconds")]
        public void Puzzle2_NumberGame_Find30000000thNumber()
        {
            var game = new NumberGame(Input.Day15);

            do
            {
                game.Turn();
            } while (game.Numbers.Count < 30_000_000);

            game.Numbers.Last().Should().Be(883);
        }

        public static IEnumerable<object[]> ExamplesFind2020thNumber()
        {
            yield return new object[] { new [] { 0, 3, 6 }, 436 };
            yield return new object[] { new [] { 1, 3, 2 }, 1 };
            yield return new object[] { new [] { 2, 1, 3 }, 10 };
            yield return new object[] { new [] { 1, 2, 3 }, 27 };
            yield return new object[] { new [] { 2, 3, 1 }, 78 };
            yield return new object[] { new [] { 3, 2, 1 }, 438 };
            yield return new object[] { new [] { 3, 1, 2 }, 1836 };
        }

        [Theory]
        [MemberData(nameof(ExamplesFind2020thNumber))]
        public void Game_Examples_Find2020thNumber(IEnumerable<int> startingList, int expectedNumber)
        {
            var game = new NumberGame(startingList);

            do
            {
                game.Turn();
            } while (game.Numbers.Count < 2020);

            game.Numbers.Last().Should().Be(expectedNumber);
        }

        public static readonly IList<int> Example = new List<int> { 0, 3, 6 };

        [Fact]
        public void Game_WithExample_GeneratesTurnsCorrectly()
        {
            var game = new NumberGame(Example);

            game.Turn().Should().Be(0);
            game.Turn().Should().Be(3);
            game.Turn().Should().Be(3);
            game.Turn().Should().Be(1);
            game.Turn().Should().Be(0);
            game.Turn().Should().Be(4);
            game.Turn().Should().Be(0);
        }
    }
}
