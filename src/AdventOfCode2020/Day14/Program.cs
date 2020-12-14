using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day14
{
    public class Program
    {
        public readonly Regex MaskFormat = new Regex(@"mask = (?'mask'[01X]+)", RegexOptions.Compiled);
        public readonly Regex MemFormat = new Regex(@"mem\[(?'location'\d+)\] = (?'value'\d+)", RegexOptions.Compiled);

        public IDictionary<int, long> Memory { get; }

        public List<string> Instructions { get; }

        public string Mask { get; private set; }

        public Program(IEnumerable<string> instructions)
        {
            Memory = new DefaultDictionary<int, long>(_ => 0L);
            Instructions = new List<string>(instructions);
        }

        public void Run()
        {
            foreach (var instruction in Instructions)
            {
                var maskMatch = MaskFormat.Match(instruction);
                if (maskMatch.Success)
                {
                    Mask = maskMatch.Groups["mask"].Value;
                    continue;
                }

                var memMatch = MemFormat.Match(instruction);
                var location = int.Parse(memMatch.Groups["location"].Value);
                var originalValue = long.Parse(memMatch.Groups["value"].Value);

                var valAsString = Convert.ToString(originalValue, 2).PadLeft(Mask.Length, '0');
                var valAsMask = new StringBuilder(valAsString);

                for (var k = 1; k <= valAsMask.Length; ++k)
                {
                    var bit = valAsMask[^k];

                    valAsMask[^k] = Mask[^k] switch
                    {
                        'X' => bit,
                        char c => c
                    };
                }

                var finalVal = valAsMask.ToString();
                Memory[location] = Convert.ToInt64(finalVal, 2);
            }
        }
    }
}
