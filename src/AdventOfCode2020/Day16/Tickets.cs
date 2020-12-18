using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day16
{
    public class Tickets
    {
        public IList<TicketField> Fields { get; }
        public IList<IList<int>> Nearby { get; }

        public Tickets(string fields, string nearbyTickets)
        {
            Fields = fields
                .SplitLines()
                .Select(x => new TicketField(x))
                .ToList();

            Nearby = nearbyTickets
                .SplitLines()
                .Select<string, IList<int>>(x => x.SplitOn(',').Select(int.Parse).ToList())
                .ToList();
        }

        public int GetErrorRate()
        {
            var errorRate = 0;

            foreach (var ticket in Nearby)
            {
                var invalidFields = ticket.Where(value => Fields.All(field => !field.IsValid(value)));
                errorRate += invalidFields.Sum();
            }

            return errorRate;
        }
    }

    public class TicketField
    {
        public static readonly Regex Format = new Regex(@"(?'name'.+): (?'low1'\d+)-(?'high1'\d+) or (?'low2'\d+)-(?'high2'\d+)", RegexOptions.Compiled);

        public string Name { get; }

        public int Low1 { get; }
        public int High1 { get; }

        public int Low2 { get; }
        public int High2 { get; }

        public TicketField(string content)
        {
            var match = Format.Match(content);

            Name = match.Groups["name"].Value;
            Low1 = int.Parse(match.Groups["low1"].Value);
            High1 = int.Parse(match.Groups["high1"].Value);
            Low2 = int.Parse(match.Groups["low2"].Value);
            High2 = int.Parse(match.Groups["high2"].Value);
        }

        public bool IsValid(int value) => value >= Low1 && value <= High1 || value >= Low2 && value <= High2;
    }
}
