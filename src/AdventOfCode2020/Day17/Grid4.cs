using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day17
{
    public class Grid4 : IEnumerable<Cube4>
    {
        public static readonly List<(int ModX, int ModY, int ModZ, int ModW)> Mods = new() // first impression is I do not like that syntax
        {

            (-1, -1, -1, -1),
            (-1, -1, -1, +0),
            (-1, -1, -1, +1),
            (-1, -1, +0, -1),
            (-1, -1, +0, +0),
            (-1, -1, +0, +1),
            (-1, -1, +1, -1),
            (-1, -1, +1, +0),
            (-1, -1, +1, +1),
            (-1, +0, -1, -1),
            (-1, +0, -1, +0),
            (-1, +0, -1, +1),
            (-1, +0, +0, -1),
            (-1, +0, +0, +0),
            (-1, +0, +0, +1),
            (-1, +0, +1, -1),
            (-1, +0, +1, +0),
            (-1, +0, +1, +1),
            (-1, +1, -1, -1),
            (-1, +1, -1, +0),
            (-1, +1, -1, +1),
            (-1, +1, +0, -1),
            (-1, +1, +0, +0),
            (-1, +1, +0, +1),
            (-1, +1, +1, -1),
            (-1, +1, +1, +0),
            (-1, +1, +1, +1),
            (+0, -1, -1, -1),
            (+0, -1, -1, +0),
            (+0, -1, -1, +1),
            (+0, -1, +0, -1),
            (+0, -1, +0, +0),
            (+0, -1, +0, +1),
            (+0, -1, +1, -1),
            (+0, -1, +1, +0),
            (+0, -1, +1, +1),
            (+0, +0, -1, -1),
            (+0, +0, -1, +0),
            (+0, +0, -1, +1),
            (+0, +0, +0, -1),
            (+0, +0, +0, +1),
            (+0, +0, +1, -1),
            (+0, +0, +1, +0),
            (+0, +0, +1, +1),
            (+0, +1, -1, -1),
            (+0, +1, -1, +0),
            (+0, +1, -1, +1),
            (+0, +1, +0, -1),
            (+0, +1, +0, +0),
            (+0, +1, +0, +1),
            (+0, +1, +1, -1),
            (+0, +1, +1, +0),
            (+0, +1, +1, +1),
            (+1, -1, -1, -1),
            (+1, -1, -1, +0),
            (+1, -1, -1, +1),
            (+1, -1, +0, -1),
            (+1, -1, +0, +0),
            (+1, -1, +0, +1),
            (+1, -1, +1, -1),
            (+1, -1, +1, +0),
            (+1, -1, +1, +1),
            (+1, +0, -1, -1),
            (+1, +0, -1, +0),
            (+1, +0, -1, +1),
            (+1, +0, +0, -1),
            (+1, +0, +0, +0),
            (+1, +0, +0, +1),
            (+1, +0, +1, -1),
            (+1, +0, +1, +0),
            (+1, +0, +1, +1),
            (+1, +1, -1, -1),
            (+1, +1, -1, +0),
            (+1, +1, -1, +1),
            (+1, +1, +0, -1),
            (+1, +1, +0, +0),
            (+1, +1, +0, +1),
            (+1, +1, +1, -1),
            (+1, +1, +1, +0),
            (+1, +1, +1, +1)
        };

        public IDictionary<(int X, int Y, int Z, int W), Cube4> Cubes { get; }

        public int ActiveCubeCount => Cubes.Count(x => x.Value.IsActive);

        public Grid4(string input)
        {
            Cubes = new DefaultDictionary<(int X, int Y, int Z, int W), Cube4>(location => new Cube4(location));

            var lines = input.SplitLines().ToList();

            for (var row = 0; row < lines.Count; ++row)
            {
                for (var col = 0; col < lines[0].Length; ++col)
                {
                    var isActive = lines[row][col] == '#';
                    Cubes[(row, col, 0, 0)].WillBe(isActive).Commit();
                }
            }

            var cubes = new List<Cube4>(Cubes.Values);
            foreach (var cube in cubes)
            {
                _ = GetActiveNeighbors(cube.Location);
            }
        }

        private int GetActiveNeighbors((int X, int Y, int Z, int W) location)
        {
            return Mods.Count(mod => Cubes[location.Add(mod)].IsActive);
        }

        public void Boot()
        {
            for (var k = 0; k < 6; k++)
            {
                Step();
            }
        }

        public void Step()
        {
            var cubes = new List<Cube4>(Cubes.Values);
            foreach (var cube in cubes)
            {
                var activeNeighbors = GetActiveNeighbors(cube.Location);

                cube.WillBeActive = cube.IsActive switch
                {
                    true when activeNeighbors is >= 2 and <= 3 => true,
                    true => false,
                    false when activeNeighbors is 3 => true,
                    false => false
                };
            }

            foreach (var cube in cubes)
            {
                cube.Commit();
            }
        }

        public IEnumerator<Cube4> GetEnumerator() => Cubes.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}