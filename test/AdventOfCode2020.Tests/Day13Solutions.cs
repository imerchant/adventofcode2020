using System.Collections.Generic;
using System.Numerics;
using AdventOfCode2020.Day13;
using AdventOfCode2020.Inputs;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2020.Tests
{
    public class Day13Solutions : TestBase
    {
        public Day13Solutions(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Puzzle1_FIndProductOfBusIdAndWaitTime()
        {
            var schedule = new Schedule(Input.Day13.Timestamp, Input.Day13.Buses);

            var (busId, timestamp) = schedule.FindFirstBusToLeave();
            var waitTime = timestamp - schedule.Timestamp;

            (busId * waitTime).Should().Be(333);
        }

        [Fact]
        public void Puzzle2_FindTimestampOfBusSequence()
        {
            var sequence = new BusSequence(Input.Day13.ParseRawIds(Input.Day13.RawBuses));

            sequence.FindTimestampWhereBusesLeaveInSequence().Should().Be(new BigInteger(690123192779524));
        }

        [Fact]
        public void Puzzle1Example_CanFindBusThatLeaves()
        {
            const int timestamp = 939;
            var buses = new [] { 7, 13, 59, 31, 19 };

            var schedule = new Schedule(timestamp, buses);

            schedule.FindFirstBusToLeave().Should().Be((59, 944));
        }

        public static IEnumerable<object[]> FindSequenceTimestampCases()
        {
            yield return new object[] { "7,13,x,x,59,x,31,19", new BigInteger(1068781) };
            yield return new object[] { "17,x,13,19", new BigInteger(3417) };
            yield return new object[] { "67,7,59,61", new BigInteger(754018) };
            yield return new object[] { "67,x,7,59,61", new BigInteger(779210) };
            yield return new object[] { "67,7,x,59,61", new BigInteger(1261476) };
            yield return new object[] { "1789,37,47,1889", new BigInteger(1202161486) };
        }

        [Theory]
        [MemberData(nameof(FindSequenceTimestampCases))]
        public void Puzzle2Examples_FindTimestamp(string rawIds, BigInteger expectedTimestamp)
        {
            var sequence = new BusSequence(Input.Day13.ParseRawIds(rawIds));

            sequence.FindTimestampWhereBusesLeaveInSequence().Should().Be(expectedTimestamp);
        }

        [Fact]
        public void Puzzle2_FindOffsets()
        {
            var rawIds = Input.Day13.ParseRawIds(Input.Day13.RawBuses);
            var offsets = new List<(int BusId, int Offset)>();

            for (var k = 0; k < rawIds.Count; ++k)
            {
                if (int.TryParse(rawIds[k], out var value))
                {
                    offsets.Add((value, k));
                }
            }

            offsets[0].Should().Be((29, 0));
            offsets[1].Should().Be((37, 23));
            offsets[2].Should().Be((467, 29));
        }
    }
}
