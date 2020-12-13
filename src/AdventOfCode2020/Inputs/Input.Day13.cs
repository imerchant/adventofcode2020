using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Inputs
{
    public static partial class Input
    {
        public static class Day13
        {
            public const int Timestamp = 1000508;
            public static int[] Buses = { 29, 37, 467, 23, 13, 17, 19, 443, 41 };
            public const string RawBuses = "29,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,37,x,x,x,x,x,467,x,x,x,x,x,x,x,23,x,x,x,x,13,x,x,x,17,x,19,x,x,x,x,x,x,x,x,x,x,x,443,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,41";

            public static List<string> ParseRawIds(string input) => input.SplitOn(',').ToList();
        }
    }
}
