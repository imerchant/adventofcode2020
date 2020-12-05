using System;
using System.Linq;
using AdventOfCode2020.Day05;
using AdventOfCode2020.Inputs;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2020.Tests
{
    public class Day05Solutions : TestBase
    {
        public Day05Solutions(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Puzzle1_FindHighestSeatId()
        {
            var airplane = new Airplane(Input.Day05Parse(Input.Day05));

            airplane.Max(x => x.Id).Should().Be(850);
        }

        [Fact]
        public void Puzzle2_FindMySeat()
        {
            var airplane = new Airplane(Input.Day05Parse(Input.Day05));

            airplane.FindEmptySeat().Should().Be(599);
        }

        [Theory]
        [InlineData("FBFBBFFRLR", 44, 5, 357)]
        [InlineData("BFFFBBFRRR", 70, 7, 567)]
        [InlineData("FFFBBBFRRR", 14, 7, 119)]
        [InlineData("BBFFBBFRLL", 102, 4, 820)]
        public void Puzzle1Example_SeatIsCalculatedCorrectly(string boardingPass, int expectedRow, int expectedColumn, int expectedId)
        {
            var seat = new Seat(boardingPass);

            seat.Row.Should().Be(expectedRow);
            seat.Column.Should().Be(expectedColumn);
            seat.Id.Should().Be(expectedId);
        }

        [Theory]
        [InlineData(0, 127, Position.Lower, 0, 63)]
        [InlineData(0, 63, Position.Upper, 32, 63)]
        [InlineData(32, 63, Position.Lower, 32, 47)]
        [InlineData(32, 47, Position.Upper, 40, 47)]
        [InlineData(40, 47, Position.Upper, 44, 47)]
        [InlineData(44, 47, Position.Lower, 44, 45)]
        [InlineData(44, 45, Position.Lower, 44, 44)]
        public void BinarySpacePartition_CalculatesCorrectly(int startLow, int startHigh, Position position,
            int expectedLow, int expectedHigh)
        {
            BinarySpacePartition(startLow, startHigh, position).Should().Be((expectedLow, expectedHigh));
        }

        private static (int Low, int High) BinarySpacePartition(int low, int high, Position position)
        {
            var middle = (high - low) / 2.0 + low;

            switch (position)
            {
                case Position.Lower:
                    var newHigh = (int) Math.Floor(middle);
                    return (low, newHigh);
                case Position.Upper:
                    var newLow = (int) Math.Ceiling(middle);
                    return (newLow, high);
                default:
                    throw new Exception("invalid position");
            }
        }

        [Fact]
        public void RangeOperations_OperateAsExpected()
        {
            const string boardingPass = "FBFBBFFRLR";

            var rowSpec = boardingPass[..7];
            var colSpec = boardingPass[7..];

            rowSpec.Should().Be("FBFBBFF");
            colSpec.Should().Be("RLR");
        }
    }
}
