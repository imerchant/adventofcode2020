using System.Linq;
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
        public void Puzzle1And2_GetTicketErrorRate_AndProductOfMyTicketDepartureFields()
        {
            var tickets = new Tickets(Input.Day16.Fields, Input.Day16.NearbyTickets, Input.Day16.MyTicket);

            tickets.Nearby.Sum(x => x.ErrorRate).Should().Be(19093);
            tickets.FindProductOfDepartureFieldsInMyTicket().Should().Be(5311123569883L);
        }

        public const string Example1Fields =
@"class: 1-3 or 5-7
row: 6-11 or 33-44
seat: 13-40 or 45-50";

        public const string Example1NearbyTickets =
@"7,3,47
40,4,50
55,2,20
38,6,12";

        [Fact]
        public void Example1_CountsFields_AndErrorRateCorrectly()
        {
            var tickets = new Tickets(Example1Fields, Example1NearbyTickets, string.Empty);

            tickets.Fields.Should().HaveCount(3);
            tickets.Nearby.Should().HaveCount(4);

            tickets.Nearby.Sum(x => x.ErrorRate).Should().Be(71);
        }
    }
}
