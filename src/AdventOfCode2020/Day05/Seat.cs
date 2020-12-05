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
            var rowSpec = boardingPass[..7];
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
                (low, high) = BinarySpacePartition(position);
            }

            return low;

            (int, int) BinarySpacePartition(Position position)
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
        }
    }
}