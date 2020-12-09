using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day09
{
    public class XmasSystem
    {
        public List<long> Numbers { get; }

        public XmasSystem(string input)
        {
            Numbers = input.SplitLines().Select(long.Parse).ToList();
        }

        public long FindFirstInvalid(int preambleLength)
        {
            for (var k = preambleLength; k < Numbers.Count; ++k)
            {
                var start = k - preambleLength;
                if (FindNumbersThatSumTo(Numbers[k], start, preambleLength) is false)
                {
                    return Numbers[k];
                }
            }

            throw new Exception("Could not locate invalid number");

            bool FindNumbersThatSumTo(long target, int start, int take)
            {
                var numbers = Numbers.Skip(start).Take(take).ToList();
                for (var a = 0; a < numbers.Count; a++)
                {
                    for (var b = 0; b < numbers.Count; b++)
                    {
                        if (a == b) continue;
                        if (numbers[a] + numbers[b] == target)
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
        }

        public List<long> FindSetThatAddsToInvalid(long target)
        {
            var set = new List<long>();

            for (var k = 0; k < Numbers.Count; ++k)
            {
                set.Clear();

                if (Numbers[k] >= target) continue;

                set.Add(Numbers[k]);
                for (var j = k+1; j < Numbers.Count; ++j)
                {
                    set.Add(Numbers[j]);
                    var sum = set.Sum();

                    if (sum == target)
                    {
                        return set;
                    }

                    if (sum > target)
                        break;
                }
            }

            throw new Exception($"Could not locate set that adds to target {target}");
        }
    }
}
