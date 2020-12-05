using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day05
{
    public class Seat
    {
        public static readonly IDictionary<char, Position> PositionMap = new Dictionary<char, Position>
        {
            { 'F', Position.Lower },
            { 'B', Position.Upper },
            { 'L', Position.Lower },
            { 'R', Position.Upper }
        };

        public int Id { get; }
        public int Row { get; }
        public int Column { get; }

        public Seat(string boardingPass)
        {
            var rowSpec = boardingPass[..7]; // finally, a use case for range expressions
            var colSpec = boardingPass[7..];

            Row = Get(rowSpec, 127);
            Column = Get(colSpec, 7);
            Id = Row * 8 + Column;
        }

        private static int Get(string spec, int highStart)
        {
            var (low, high) = (0, highStart);
            foreach (var position in spec.Select(x => PositionMap[x]))
            {
                // binary space partition
                double middle = (high - low) / 2.0 + low; // if 'double' inspection says to use var, if 'var' ReSharper drops an inlay hint because it isn't descriptive enough. sigh.

                (low, high) = position switch
                {
                    Position.Lower => (low,                        (int) Math.Floor(middle)), // tie goes to the lower partition, I guess
                    Position.Upper => ((int) Math.Ceiling(middle), high),
                    _ => throw new Exception("invalid position")
                };
            }

            return low;
        }
    }
}