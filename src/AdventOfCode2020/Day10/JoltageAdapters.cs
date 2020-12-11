using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day10
{
    public class JoltageAdapters : IEnumerable<int>
    {
        public List<int> Adapters { get; }

        public JoltageAdapters(string input)
        {
            Adapters = input.SplitLines().Select(int.Parse).ToList();

            Adapters.Add(0);
            Adapters = Adapters.OrderBy(x => x).ToList();
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

        public IEnumerator<int> GetEnumerator() => Adapters.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
