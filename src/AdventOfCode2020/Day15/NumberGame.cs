using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day15
{
    public class NumberGame
    {
        public IList<int> Numbers { get; }

        public IDictionary<int, List<int>> Indexes { get; }

        public NumberGame(IEnumerable<int> numbers)
        {
            Numbers = new List<int>(numbers);
            Indexes = new DefaultDictionary<int, List<int>>(_ => new List<int>());

            for (var k = 0; k < Numbers.Count; ++k)
            {
                Indexes[Numbers[k]].Add(k);
            }
        }

        public int Turn()
        {
            var last = Numbers.Last();
            var age = 0;

            if (TryPreviousInstance(out var previousIndex))
            {
                age = Numbers.Count - 1 - previousIndex; // Numbers.Count - 1 because of indexing at 0
            }

            Indexes[age].Add(Numbers.Count);
            Numbers.Add(age);

            return age;

            bool TryPreviousInstance(out int previous)
            {
                previous = -1;
                if (Indexes.TryGetValue(last, out var indexes) && indexes.Count > 1)
                {
                    previous = indexes[^2];
                    return true;
                }

                return false;
            }
        }
    }
}
