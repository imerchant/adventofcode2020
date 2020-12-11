using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day10
{
    public class JoltageAdapters : IEnumerable<int>
    {
        public List<int> Adapters { get; }
        public long Permutations { get; }

        public JoltageAdapters(string input)
        {
            Adapters = input.SplitLines().Select(int.Parse).ToList();
            Adapters.Add(0);
            Adapters = Adapters.OrderBy(x => x).ToList();

            Permutations = CountPermutations();

            Adapters.Add(Adapters.Last() + 3);
        }

        public (int Of1, int Of3) GetDifferences()
        {
            var of1 = 0;
            var of3 = 0;

            for (var k = 0; k < Adapters.Count - 1; k++)
            {
                var first = Adapters[k];
                var second = Adapters[k + 1];

                var difference = second - first;

                _ = difference switch
                {
                    1 => of1++,
                    3 => of3++,
                    _ => 0
                };
            }

            return (of1, of3);
        }

        // group them into sublists of chains of differences of 1, multiply the permutations of the sublists
        private long CountPermutations()
        {
            var sublists = new List<List<int>>();

            var sublist = new List<int> { 0 };
            for (var k = 1; k < Adapters.Count; ++k)
            {
                var diff = Adapters[k] - Adapters[k - 1];

                if (diff == 3)
                {
                    sublists.Add(sublist);
                    sublist = new List<int> { Adapters[k] };
                    continue;
                }

                sublist.Add(Adapters[k]);
            }

            sublists.Add(sublist);

            return sublists.Aggregate(1L, (accumulator, list) => accumulator * Permutations(list));

            static int Permutations(ICollection<int> list) => // apparently this is something called the tribonacci sequence?
                list.Count switch
                {
                    1 => 1,
                    2 => 1,
                    3 => 2,
                    4 => 4,
                    5 => 7,
                    _ => throw new Exception($"could not find a way to find permutations for {string.Join(",", list)}")
                };
        }

        public IEnumerator<int> GetEnumerator() => Adapters.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
