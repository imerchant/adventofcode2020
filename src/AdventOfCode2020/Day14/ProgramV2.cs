using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day14
{
    public class ProgramV2
    {
        public readonly Regex MaskFormat = new Regex(@"mask = (?'mask'[01X]+)", RegexOptions.Compiled);
        public readonly Regex MemFormat = new Regex(@"mem\[(?'location'\d+)\] = (?'value'\d+)", RegexOptions.Compiled);

        public IDictionary<long, long> Memory { get; }

        public List<string> Instructions { get; }

        public string Mask { get; private set; }

        public ProgramV2(IEnumerable<string> instructions)
        {
            Memory = new DefaultDictionary<long, long>(_ => 0L);
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
                var originalLocation = int.Parse(memMatch.Groups["location"].Value);
                var value = long.Parse(memMatch.Groups["value"].Value);

                var locationAsString = Convert.ToString(originalLocation, 2).PadLeft(Mask.Length, '0');
                var locationAsMask = new StringBuilder(locationAsString);

                for (var k = 1; k <= locationAsMask.Length; ++k)
                {
                    var bit = locationAsMask[^k];

                    locationAsMask[^k] = Mask[^k] switch
                    {
                        'X' => 'X',
                        '1' => '1',
                        _ => bit
                    };
                }

                var locationMasks = new HashSet<string>();
                var stack = new Stack<string>();
                stack.Push(locationAsMask.ToString());

                do
                {
                    var mask = stack.Pop();
                    var firstX = mask.IndexOf('X');
                    if (firstX >= 0)
                    {
                        var builder = new StringBuilder(mask);
                        builder[firstX] = '1';
                        stack.Push(builder.ToString());

                        builder[firstX] = '0';
                        stack.Push(builder.ToString());
                        continue;
                    }

                    locationMasks.Add(mask);
                } while (stack.TryPeek(out _));

                var locations = locationMasks.Select(x => Convert.ToInt64(x, 2));

                foreach (var location in locations)
                {
                    Memory[location] = value;
                }
            }
        }
    }
}