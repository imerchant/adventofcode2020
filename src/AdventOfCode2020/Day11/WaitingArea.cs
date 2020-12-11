using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day11
{
    public class WaitingArea
    {
        private static readonly List<Mod> Mods = new List<Mod>
        {
            new Mod(-1,  0),
            new Mod(-1,  1),
            new Mod( 0,  1),
            new Mod( 1,  1),
            new Mod( 1,  0),
            new Mod( 1, -1),
            new Mod( 0, -1),
            new Mod(-1, -1)
        };

        private readonly HashSet<string> _permutations;

        public ISpot[,] Grid { get; }

        public int Height { get; }
        public int Width { get; }

        public int OccupiedSeats => Grid.OfType<ISpot>().Count(x => x.CurrentlyIs == Occupied.Yes);

        public WaitingArea(string input)
        {
            _permutations = new HashSet<string>();

            var lines = input.SplitLines().ToList();
            Height = lines.Count;
            Width = lines.First().Length;

            Grid = new ISpot[Height, Width];

            for (var row = 0; row < Height; row++)
            {
                for (var col = 0; col < Width; col++)
                {
                    Grid[row, col] = lines[row][col] switch
                    {
                        'L' => new Seat(row, col),
                        _ => new Floor()
                    };
                }
            }
        }

        public bool Tick()
        {
            foreach (var seat in Grid.OfType<Seat>())
            {
                var neighbors = Mods.Count(mod => IsOccupied(seat.Row + mod.Row, seat.Col + mod.Col));

                seat.WillBe = seat.CurrentlyIs switch
                {
                    Occupied.No when neighbors == 0 => Occupied.Yes,
                    Occupied.Yes when neighbors >= 4 => Occupied.No,
                    _ => seat.CurrentlyIs
                };
            }

            foreach (var seat in Grid.OfType<Seat>())
            {
                seat.Commit();
            }

            return _permutations.Add(ToString());

            bool IsOccupied(int row, int col)
            {
                if (row < 0 || row >= Height || col < 0 || col >= Width) return false;

                return Grid[row, col].CurrentlyIs == Occupied.Yes;
            }
        }

        public override string ToString() => string.Join(string.Empty, Grid.Cast<ISpot>());
    }
}
