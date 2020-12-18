using AdventOfCode2020.Day16;
using AdventOfCode2020.Inputs;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2020.Tests
{
    public class Day16Solutions : TestBase
    {
        public Day16Solutions(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Puzzle1_GetTicketErrorRate()
        {
            var tickets = new Tickets(Input.Day16.Fields, Input.Day16.NearbyTickets);

            tickets.GetErrorRate().Should().Be(19093);
        }

        public const string ExampleFields =
@"class: 1-3 or 5-7
row: 6-11 or 33-44
seat: 13-40 or 45-50";

        public const string ExampleNearbyTickets =
@"7,3,47
40,4,50
55,2,20
38,6,12";

        [Fact]
        public void Example_CountsFields_AndErrorRateCorrectly()
        {
            var tickets = new Tickets(ExampleFields, ExampleNearbyTickets);

            tickets.Fields.Should().HaveCount(3);
            tickets.Nearby.Should().HaveCount(4);

            tickets.GetErrorRate().Should().Be(71);
        }
    }
}
