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

        public int OccupiedSeats => Grid.OfType<ISpot>().Count(x => x.IsOccupied);

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

        public bool Puzzle1Tick()
        {
            foreach (var seat in Grid.OfType<Seat>())
            {
                var neighbors = Mods.Count(mod => IsOccupied(seat.Row + mod.Row, seat.Col + mod.Col));

                seat.WillBeOccupied = seat.IsOccupied switch
                {
                    false when neighbors == 0 => true,
                    true when neighbors >= 4 => false,
                    _ => seat.IsOccupied
                };
            }

            foreach (var seat in Grid.OfType<Seat>())
            {
                seat.Commit();
            }

            return _permutations.Add(ToString());

            bool IsOccupied(int row, int col) => IsInBounds(row, col) && Grid[row, col].IsOccupied;
        }

        public bool Puzzle2Tick()
        {
            foreach (var seat in Grid.OfType<Seat>())
            {
                var neighbors = Mods.Count(mod => IsOccupied(seat, mod));

                seat.WillBeOccupied = seat.IsOccupied switch
                {
                    false when neighbors == 0 => true,
                    true when neighbors >= 5 => false,
                    _ => seat.IsOccupied
                };
            }

            foreach (var seat in Grid.OfType<Seat>())
            {
                seat.Commit();
            }

            return _permutations.Add(ToString());

            bool IsOccupied(Seat seat, Mod mod)
            {
                var (row, col) = (seat.Row, seat.Col);

                while (IsInBounds(row + mod.Row, col + mod.Col))
                {
                    (row, col) = (row + mod.Row, col + mod.Col);
                    if (Grid[row, col] is Seat otherSeat)
                        return otherSeat.IsOccupied;
                }

                return false;
            }
        }

        public override string ToString() => string.Join(string.Empty, Grid.Cast<ISpot>());

        private bool IsInBounds(int row, int col) => row >= 0 && row < Height && col >= 0 && col < Width;
    }
}
