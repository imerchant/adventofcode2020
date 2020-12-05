using System;
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

        public int FindEmptySeat()
        {
            var seats = Seats.Select(x => x.Id).OrderBy(x => x).ToList();

            for (var k = seats.First(); k < seats.Last(); ++k)
            {
                if (!seats.Contains(k))
                {
                    return k;
                }
            }

            throw new Exception("Could not locate empty seat");
        }

        public IEnumerator<Seat> GetEnumerator() => Seats.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
