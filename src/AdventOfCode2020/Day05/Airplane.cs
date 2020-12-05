using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day05
{
    public class Airplane : IEnumerable<Seat>
    {
        public List<Seat> Seats { get; }

        public Airplane(IEnumerable<string> boardingPasses)
        {
            Seats = boardingPasses.Select(x => new Seat(x)).ToList();
        }

        public IEnumerator<Seat> GetEnumerator() => Seats.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
