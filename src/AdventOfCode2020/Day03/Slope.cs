using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day03
{
    public class Slope
    {
        public const char Tree = '#';

        public List<string> Grid { get; }

        public (int Right, int Down) FirstSledAngle { get; } = (3, 1);

        public int X { get; private set; } = 0;
        public int Y { get; private set; } = 0;

        public char CurrentLocation => Grid[Y][X % Grid[0].Length];

        public Slope(string input)
        {
            Grid = input.SplitLines().ToList();
        }

        public int CountTreesOnDescent((int Right, int Down) angle)
        {
            var trees = 0;

            do
            {
                if (CurrentLocation == Tree)
                    trees++;

                Y += angle.Down;
                X += angle.Right;

            } while (Y < Grid.Count);

            return trees;
        }
    }
}
