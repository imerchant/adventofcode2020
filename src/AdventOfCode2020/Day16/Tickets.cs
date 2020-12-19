using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day16
{
    public class Tickets
    {
        public IList<Field> Fields { get; }
        public IList<Ticket> Nearby { get; }
        public Ticket MyTicket { get; }
        public IList<Ticket> ValidTickets { get; }

        public Tickets(string fields, string nearbyTickets, string myTicket)
        {
            Fields = fields
                .SplitLines()
                .Select(x => new Field(x))
                .ToList();

            Nearby = nearbyTickets
                .SplitLines()
                .Select(x => new Ticket(x.SplitOn(',').Select(int.Parse), Fields))
                .ToList();

            MyTicket = new Ticket(myTicket.SplitOn(',').Select(int.Parse), Fields);

            ValidTickets = new List<Ticket>(Nearby.Where(x => x.IsValid)) { MyTicket };
        }

        public long FindProductOfDepartureFieldsInMyTicket()
        {
            // find all valid indices for each field
            var indices = Enumerable.Range(0, MyTicket.Count).ToList();
            foreach (var field in Fields)
            {
                field.Indices.AddRange(indices.Where(index => FieldIsValidForValuesAtIndex(field, index)));
            }

            // identify fields with only one possible position, and consecutively cull that position from other fields until
            // each has only one position
            do
            {
                var singles = Fields.Where(field => field.Indices.Count == 1).ToList();

                foreach (var single in singles)
                {
                    foreach (var field in Fields.Where(field => field.Indices.Count > 1).ToList())
                    {
                        field.Indices.Remove(single.Index);
                    }
                }
            } while (Fields.Any(field => field.Indices.Count > 1));

            // gather the departure fields and return the product of the values in my ticket
            var departureFields = Fields.Where(x => x.Name.Contains("departure"));

            return departureFields.Aggregate(1L, (accumulator, field) => accumulator * MyTicket[field.Index]);

            bool FieldIsValidForValuesAtIndex(Field field, int index) =>
                ValidTickets
                    .Select(ticket => ticket[index])
                    .All(field.IsValid);
        }
    }
}
