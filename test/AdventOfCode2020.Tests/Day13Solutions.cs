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
        public void Puzzle1_FundProductOfBusIdAndWaitTime()
        {
            var schedule = new Schedule(Input.Day13.Timestamp, Input.Day13.Buses);

            var (busId, timestamp) = schedule.FindFirstBusToLeave();
            var waitTime = timestamp - schedule.Timestamp;

            (busId * waitTime).Should().Be(333);
        }

        [Fact]
        public void Puzzle1Example_CanFindBusThatLeaves()
        {
            const int timestamp = 939;
            var buses = new [] { 7, 13, 59, 31, 19 };

            var schedule = new Schedule(timestamp, buses);

            schedule.FindFirstBusToLeave().Should().Be((59, 944));
        }
    }
}
