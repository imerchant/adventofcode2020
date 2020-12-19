using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2020.Day17;
using AdventOfCode2020.Inputs;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2020.Tests
{
    public class Day17Solutions : TestBase
    {
        public Day17Solutions(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Puzzle1_3DCubeGrid_FindActiveCubesAfterBoot()
        {
            var grid = new Grid3(Input.Day17);

            grid.Boot();

            grid.ActiveCubeCount.Should().Be(298);
        }

        [Fact]
        public void Puzzle1_4DCubeGrid_FindActiveCubesAfterBoot()
        {
            var grid = new Grid4(Input.Day17);

            grid.Boot();

            grid.ActiveCubeCount.Should().Be(1792);
        }

        public const string Example1 =
@".#.
..#
###";

        [Fact]
        public void GridExample1_CountsActiveCubes_AfterBoot()
        {
            var grid = new Grid3(Example1);

            grid.Boot();

            grid.ActiveCubeCount.Should().Be(112);
        }

        [Fact]
        public void Grid_IngestsInputCorrectly()
        {
            var grid = new Grid3(Example1);

            grid.Cubes.Should().HaveCount(75); // because we initialize the neighbors now too
            grid.Count(x => x.IsActive).Should().Be(5);
        }

        [Fact]
        public void BuildModsWithLoops3()
        {
            var list = new List<(int, int, int)>();

            for (var x = -1; x <= 1; ++x)
            {
                for (var y = -1; y <= 1; ++y)
                {
                    for (var z = -1; z <= 1; ++z)
                    {
                        if ((x, y, z) == (0, 0, 0)) continue;
                        list.Add((x, y, z));
                    }
                }
            }

            list.Should().HaveCount(26);
            Output.WriteLine(string.Join(Environment.NewLine, list.Select(x => $"({x.Item1:+0;-0}, {x.Item2:+0;-0}, {x.Item3:+0;-0})")));
        }

        [Fact]
        public void BuildModsWithLoops4()
        {
            var list = new List<(int, int, int, int)>();

            for (var x = -1; x <= 1; ++x)
            {
                for (var y = -1; y <= 1; ++y)
                {
                    for (var z = -1; z <= 1; ++z)
                    {
                        for (var w = -1; w <= 1; w++)
                        {
                            if ((x, y, z, w) == (0, 0, 0, 0)) continue;
                            list.Add((x, y, z, w));
                        }
                    }
                }
            }

            list.Should().HaveCount(80);
            Output.WriteLine(string.Join(Environment.NewLine, list.Select(x => $"({x.Item1:+0;-0}, {x.Item2:+0;-0}, {x.Item3:+0;-0}, {x.Item4:+0;-0})")));
        }
    }
}
