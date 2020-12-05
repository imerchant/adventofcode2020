using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day03
{
    public class Slope
    {
        public const char Tree = '#';
        public static (int Right, int Down) FirstSledAngle = (3, 1);
        public static readonly List<(int Right, int Down)> AllAngles = new List<(int, int)>
        {
            (1, 1),
            (3, 1),
            (5, 1),
            (7, 1),
            (1, 2)
        };

        public List<string> Grid { get; }


        public int X { get; private set; } = 0;
        public int Y { get; private set; } = 0;

        public char CurrentLocation => Grid[Y][X % Grid[0].Length];

        public Slope(string input)
        {
            Grid = input.SplitLines().ToList();
        }

        public long CountTreesOnDescent((int Right, int Down) angle)
        {
            var trees = 0;

            do
            {
                if (CurrentLocation == Tree)
                    trees++;

                Y += angle.Down;
                X += angle.Right;

            } while (Y < Grid.Count);

            (X, Y) = (0, 0);

            return trees;
        }

        public long MultiplyTreesOnAllAngles()
        {
            var results = AllAngles.Select(CountTreesOnDescent).ToList();

            return results.Aggregate(1L, (state, item) => state * item);
        }
    }
}
