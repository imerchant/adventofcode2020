using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day15
{
    public class NumberGame
    {
        public IList<int> Numbers { get; }

        public NumberGame(IEnumerable<int> numbers)
        {
            Numbers = new List<int>(numbers);
        }

        public int Turn()
        {
            var last = Numbers.Last();
            var age = 0;

            if (TryPreviousInstance(out var previousIndex))
            {
                age = Numbers.Count - 1 - previousIndex; // Numbers.Count - 1 because of indexing at 0
            }

            Numbers.Add(age);

            return age;

            bool TryPreviousInstance(out int previous)
            {
                previous = -1;
                for (var k = 2; k <= Numbers.Count; ++k)
                {
                    var checking = Numbers[^k];
                    if (checking == last)
                    {
                        previous = Numbers.Count - k;
                        return true;
                    }
                }

                return false;
            }
        }
    }
}
