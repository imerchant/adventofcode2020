﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Inputs
{
    public static partial class Input
    {
        public const string Day03 =
@"....#...............#.#..###.##
.#..#....###..............##...
....###......#....#.#...#.##..#
.......#........#..###...##....
.....#..#......#..#..##..#...#.
....#..........#....#...#......
............###...#............
##......#.....#......#.....##..
........#.........##..#.#...##.
....#.#..#.#...#........#..#...
.#.....#.#......#....#..#..#..#
#.##..##......#.....##...#..#..
#........#..##...###....##.....
......#.#..##...#.#.....#......
##.......#..#.........#...#....
.....##.........#....#.#.###.#.
..##...........#.#.#.#.....#.#.
....#...............#......#.#.
#.#..#....#.....#.....##...#..#
#......#..............#.#.##...
......###.....#...#........###.
####...#.....#...#....#........
.......#...#....##...#.........
.####..##............#.........
#.#...#...#....#...#.#......#..
..#..#.....#.......#...#.#...##
.#.........#...#......##.#...#.
.#.#...#...#.....#.#........#.#
.#.....###....###..##.#..##.#..
.....##....#......#..#...#...#.
#...##....#.......#.....##.##..
#...#.....#.#...........#..###.
##.#........###...........###.#
#...#.#........#.#.....#.......
..................#..#.........
.....#.#..#.#......#..#.....##.
.#.#.......#..##........#..##.#
.#.#..#.#...#.......#.#.#..#...
...#......#....#....##.#..#....
......#.......##....##..#.....#
...#.##...##...............#..#
.###....#.#.....##..#.......#.#
#....#..........#...........#.#
...#...............#.#..#....#.
.....#..##..........#..###.....
.....####.....#.#.......#...#..
#.............#...#.......##...
.#....##.......#.#......#.#.##.
.#..#.......#..##...#...#......
#.......#..#..#..#.....#.......
##...#.#.#...........#....#....
.......#..#.#..............#.#.
.....#.......#.......#.#.#.....
....##.##.....#......#.......#.
#...#..#.#....###....##...#.#.#
#..#......#........#.#.#.....#.
###..##..#......#.....#.......#
..##....#.#.#......#..##...#...
.....#..#....#...#.#...#...#...
.....#.#..###.#..#...##......#.
#.#..#....#..#.....#.#...#.#...
.#..#....#.......#..#.......#..
#.........#..#..#.........##..#
..##.##..#..#...##.............
.....###...#..#...##.#..#......
#.##.....##..............#.....
.......#.##.#.##...#.#.......##
...#.#.##...#......#...........
##.#........#.....##.....#.....
.#.....#.............#......#..
....#..##..#..#....#..#.#......
.#.....#....##..##..#...##.....
.##........#.#.#.#..........#.#
...#.#.#..#....#...#..###.##...
.#....#....#.#.#.#....#..#.....
#.#.......#..#..#...........#.#
.....#.....##..#....##.........
....#.##..............#........
.................#....#.......#
...................###...#...#.
...#.#..#..##..##....#.....#...
#...#..........................
.......#..#..#.#..#.....#......
..##.#..#......#...#.##..##..#.
.##.........#.#...........#....
...#...#..##.#......#..#..#....
.....#.#....#...#............#.
.##..#.....##....#...#.........
#......##...#...#............#.
.....#.##...#.#....##..........
.............#.......#.#.......
##....#.#........#....#..##....
....#...##.#....##..#.....#.#..
...##..#....##......#...#......
.####.#..#..#.#...#.#.#....#...
.#........#.##....#.#....#.....
.........#....##..#..#.........
....##...#....##.............#.
....#..##.#....#.#..#...##.....
.....##...#..#....#......#.#...
..........#.......#.##..#.##..#
.......#.........#...#.##......
....##.#.......#...............
....#.......#..##.......##.#.##
#.#..#.#....#.#.........###...#
.#.##.....##..##...........#.#.
...#....##........##...#...#...
.#.##....#.#...#.#..#..#...#...
#....#.##...#.#..#....#.....#..
#..#...#........#...........#..
...........#.......#......#..#.
....##...#......##.....#......#
.#.##.#.#.............#....##..
.#...#...##.#.#........#..##.#.
.#.#........#.#...#..#........#
.###.#.#...#..#..#.#....#..#...
..##..##....#.#............#...
#..........#........#..#.#.#...
.#...#..#..#.#.....#.....#....#
#.....#.#.#.....####.......#...
...#.#........#.#.###...#.....#
.....#.....##....#....#..##...#
..#....###.##.#..#..#....#...#.
.....#.....#...........#.#.###.
.....#......###...#.#...##.....
...........###..#...#....#.#..#
...#..###.....#....#.#...#.....
.......#...#..#..##....#.#.#...
...#..####.###........#.....#..
..#......###..#..#.##..........
....#....##..##..##.......###..
...#.......#..#.#....##........
.#.#.....#.#.#..........#..#..#
.##....##....##...........##.##
........#......#.##....##...#.#
..#.#.....#..#....#..........#.
...........#...............#...
.....####.....#.....###.#..#...
..........####..##.##.#....#...
...#.#.#......#....#..#.#......
.#.#......###.....#....#.......
..#..#..#.......#..#...#.....#.
...#............#......##...###
......#.............#..#..###..
.#.#......#..##.#..#..#.#...#.#
.#.....#.......#..#...........#
..#.###.#..#...#.##..#.##......
....#.#........#..#.#...#.#.##.
.#..##.#..#.#.#...##..#.#......
.......#..#..#..#.....#.#.#..#.
.##.###..##.....#.##..#........
...##..............#.#.##....#.
##....#...#...........#........
..#........#.#.##..#.#...#..#..
.......#.......##.#..#....#.#..
.......#....##..#.#.#..#....#..
..........#....#..#..#....#....
........#.....#.#.....##.......
........##.###.........#.#.#...
###......####...#.#........#...
......#........#......#.....#..
##..#.##..##.###..#........##..
.#..#...#............##.##..#..
...........#..#.#..............
.##.#.#....#...............#..#
.........##.................#..
#............##..##.........##.
##........#.........#..##.#...#
........#.....#..#.........#.##
....#......#.....##.##.........
.#.#.....#.#..#..##....#....#..
.###...#..##....##.....#.#..##.
.#....#.#.......#..#..#...###..
..#.#......#.#..#.....###.....#
#....#..#...#.....#.......#.##.
.#.......##.#.#...#......#.....
###....#.#......#....#.#...##..
...#....####.......##.....#..#.
.#.................#.......##.#
...#.###..........#..##......#.
.....##.#..............##..#...
#.....#..#..........#..#.......
..#...#.#.#.......##.#.....#...
#........#.#........#.#.....#..
#.....#...##....##..##........#
.#.##..#...#....#........#..#..
#..#.....#....#...##......#....
...#...#...#.#.#....##....#.#.#
......#...............#.....#..
.......#.#..#..##.#.....#......
...........##......#...#.......
....##..##.....#.#...#.........
......##..###.......#....#.##..
......#..#.##....#..###..#.....
.....#.........#........##.....
.....####..................#...
.#.#...##................#.....
.#..#...#...#.....#.##..#..#...
.#................#...###....#.
...#....#...........#...#....#.
.......#....##...............#.
.#.#.##..##.......#....#....###
......#.#....#...#..#..........
....#.##.#.#...##.#.#......#...
##....#...##.....#..#.###.#....
.......#......#.........#.#...#
.##.#...........##.........#.#.
##..##.....#...#..#.#...#....#.
#..##......###........#...#....
.....#.#.......#...#..##....##.
.....#.#..#.....#.......#..##..
...#..#..............#.#.......
.#.#...###......###............
.....#.....#...#.###...........
.......#..................#...#
#....#...#...#....#....#.#....#
....#..#............#.#........
#....#..........#.#.#..#..#....
.......#....#......#....#......
.##.#.#...#...#...##...........
.........###.#..#..............
...#........##....#....#....###
....##..#.......#.#...#.#..#.#.
.....##....#..##.........#.....
........##..#........#.........
...........#..#.##..##...#.....
.........#.#..####..#...#.##.##
##..#.#.....##.....#.........#.
..#...#...#....#.#....#.....#.#
.###.#....#.#......#....#......
.##.....#....#.......#.#..#.##.
#..#..##.....#....#...##.....#.
...#.........####.........##..#
..#.....#....###.#.#...#..#....
.........#....#..#.#.........#.
.....###.##..#...#.....#..#..#.
....#......#..#.#...#.....#....
.......#...#..#....#.......#.#.
.#....#............#....####...
#..##..##....#.....#...#.....#.
...#...##...#.#....#...........
.......#####.....#..###.#..#...
.....#.....#.#....#.........#..
.###.#..#...##.##.#.#..#..#....
.#..#.##..#......#..........##.
##....#....#.........###..#....
..#.............#.......#.#....
..#.....#..##...#...###..#.##..
##...##...#.#....#..#..........
...............#.....#.......#.
....#.#......##.#......#...#.#.
.........#.............#.#.....
...#.#.........................
..#..#....##..#...###.##.......
...##.#...##..#.#.##.#...#.##..
.##....#....#.......#.....##..#
.#...............#..#...#......
...##.....##.###....#.....#...#
...#.....#...####....##....#..#
..#.#.###..##.....#........#...
.....##.##..#..#.........##....
........##.....#..........#.##.
..##.#....####..#...........#..
##....#..#..#.#.##.....#...##..
...#...#......#..#.#....#......
##.....##.......##.##....#.....
.........#...##...........#....
.###.#..#....##...#.....#.....#
...#..........#.###..##...#.##.
...#..#....#.#.#.......###.....
....#..#.#.....##...#.#.#.#....
.......##..#...##..##.#....#...
.##..........#.#.#.....#.....#.
#....#......##...#..##.#..#..#.
.#...#.....###..#......#.....#.
.#..#.###.......#.##....###....
#....#....#....#....#..#.##....
..#..#.....#.....#....###.....#
##.###..#...##.......#.#.......
#...##......##....#.#...#....#.
..##.#.#....#...#.....##.......
.#....#..#...#...##..##........
###......#.##....#.#..##.......
...#.....##.#.........#..#.....
.......#.#....#.....##......#..
#..#..............##.#........#
....#.#....#..#.#...##.........
..........#..........#.........
.#.....#.....#.##....#.##..#..#
.......#.......#.#.#.##....#...
..#...........#....#.......##..
..#.#.#.#...##..#.#.#..#...#.#.
..#..#..........#...##....#....
....##.#....#.............#....
.##...##..........#.#..#...#...
#..#..#.##..........##.........
............#.......#..#.....##
....#......#........#..#.##....
#.#......#.#...#.....#.........
..#.....#..#..........#.....#..
.#..#.#.#.##...#..#.#.........#
#...##....#..##..#...#.#.##....
#..##.##.#.##.......#.......#..
#.#.......#........#.##....#.#.
....#..##....##..##......#..##.
#.....#....#.#........####.....
......#...#...###..#...........
.##.#.##...##................##
..##.#.....#.#..#......#.#.....
......#...#........#.....#.##..
#..#.#..#.....#.#..#..##..#.#..
...#.........#.#.#.##...#......
...#..##....#..#.#....#.###.#..
........###................##.#
##...........#......##.##.....#
.#.#.#....#....#....#..........
#.....#........................
....#.....#...#......#.........
....#.#..#..............#......
##.........#..#....#.......#...
.###....#..#.#.####.........#..
..#.#....#.....###..#..........
..........#................#.##";
    }
}