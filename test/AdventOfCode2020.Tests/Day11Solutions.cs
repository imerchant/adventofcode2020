using AdventOfCode2020.Day11;
using AdventOfCode2020.Inputs;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2020.Tests
{
    public class Day11Solutions : TestBase
    {
        public Day11Solutions(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Puzzle1_FindOccupiedSeatCount_AfterPatternStabilizes()
        {
            var area = new WaitingArea(Input.Day11);

            bool result;
            do
            {
                result = area.Puzzle1Tick();
            } while (result is true);

            area.OccupiedSeats.Should().Be(2361);
        }

        [Fact]
        public void Puzzle2_FindOccupiedSeatCount_WithModifiedAlgorithm()
        {
            var area = new WaitingArea(Input.Day11);

            bool result;
            do
            {
                result = area.Puzzle2Tick();
            } while (result is true);

            area.OccupiedSeats.Should().Be(2119);
        }

        public const string Example =
@"L.LL.LL.LL
LLLLLLL.LL
L.L.L..L..
LLLL.LL.LL
L.LL.LL.LL
L.LLLLL.LL
..L.L.....
LLLLLLLLLL
L.LLLLLL.L
L.LLLLL.LL";

        [Fact]
        public void WaitingArea_GridInitializedCorrectly()
        {
            var area = new WaitingArea(Example);

            area.ToString().Should().Be("L.LL.LL.LLLLLLLLL.LLL.L.L..L..LLLL.LL.LLL.LL.LL.LLL.LLLLL.LL..L.L.....LLLLLLLLLLL.LLLLLL.LL.LLLLL.LL");
        }

        [Theory]
        [InlineData(1, true,  "#.##.##.#########.###.#.#..#..####.##.###.##.##.###.#####.##..#.#.....###########.######.##.#####.##")]
        [InlineData(2, true,  "#.LL.L#.###LLLLLL.L#L.L.L..L..#LLL.LL.L##.LL.LL.LL#.LLLL#.##..L.L.....#LLLLLLLL##.LLLLLL.L#.#LLLL.##")]
        [InlineData(3, true,  "#.##.L#.###L###LL.L#L.#.#..#..#L##.##.L##.##.LL.LL#.###L#.##..#.#.....#L######L##.LL###L.L#.#L###.##")]
        [InlineData(4, true,  "#.#L.L#.###LLL#LL.L#L.L.L..#..#LLL.##.L##.LL.LL.LL#.LL#L#.##..L.L.....#L#LLLL#L##.LLLLLL.L#.#L#L#.##")]
        [InlineData(5, true,  "#.#L.L#.###LLL#LL.L#L.#.L..#..#L##.##.L##.#L.LL.LL#.#L#L#.##..L.L.....#L#L##L#L##.LLLLLL.L#.#L#L#.##")]
        [InlineData(6, false,  "#.#L.L#.###LLL#LL.L#L.#.L..#..#L##.##.L##.#L.LL.LL#.#L#L#.##..L.L.....#L#L##L#L##.LLLLLL.L#.#L#L#.##")]
        public void WaitingArea_Puzzle1Ticks_HaveCorrectPatternResults(int numTicks, bool expectedTickResult, string expectedGrid)
        {
            var area = new WaitingArea(Example);
            bool? result = null;

            for (var k = 0; k < numTicks; ++k)
            {
                result = area.Puzzle1Tick();
            }

            result.Should().Be(expectedTickResult);
            area.ToString().Should().Be(expectedGrid);
        }

        [Fact]
        public void WaitingArea_Example_Has37SeatsWhenStablePatternIsFound()
        {
            var area = new WaitingArea(Example);

            bool result;
            do
            {
                result = area.Puzzle1Tick();
            } while (result is true);

            area.OccupiedSeats.Should().Be(37);
        }

        [Theory]
        [InlineData(1, true,  "#.##.##.#########.###.#.#..#..####.##.###.##.##.###.#####.##..#.#.....###########.######.##.#####.##")]
        [InlineData(2, true,  "#.LL.LL.L##LLLLLL.LLL.L.L..L..LLLL.LL.LLL.LL.LL.LLL.LLLLL.LL..L.L.....LLLLLLLLL##.LLLLLL.L#.LLLLL.L#")]
        [InlineData(3, true,  "#.L#.##.L##L#####.LLL.#.#..#..##L#.##.###.##.#L.###.#####.#L..#.#.....LLL####LL##.L#####.L#.L####.L#")]
        [InlineData(4, true,  "#.L#.L#.L##LLLLLL.LLL.L.L..#..##LL.LL.L#L.LL.LL.L##.LLLLL.LL..L.L.....LLLLLLLLL##.LLLLL#.L#.L#LL#.L#")]
        [InlineData(5, true,  "#.L#.L#.L##LLLLLL.LLL.L.L..#..##L#.#L.L#L.L#.#L.L##.L####.LL..#.#.....LLL###LLL##.LLLLL#.L#.L#LL#.L#")]
        [InlineData(6, true,  "#.L#.L#.L##LLLLLL.LLL.L.L..#..##L#.#L.L#L.L#.LL.L##.LLLL#.LL..#.L.....LLL###LLL##.LLLLL#.L#.L#LL#.L#")]
        [InlineData(7, false, "#.L#.L#.L##LLLLLL.LLL.L.L..#..##L#.#L.L#L.L#.LL.L##.LLLL#.LL..#.L.....LLL###LLL##.LLLLL#.L#.L#LL#.L#")]
        public void WaitingArea_Puzzle2Ticks_HaveCorrectPatternResults(int numTicks, bool expectedTickResult, string expectedGrid)
        {
            var area = new WaitingArea(Example);
            bool? result = null;

            for (var k = 0; k < numTicks; ++k)
            {
                result = area.Puzzle2Tick();
            }

            result.Should().Be(expectedTickResult);
            area.ToString().Should().Be(expectedGrid);
        }
    }
}
