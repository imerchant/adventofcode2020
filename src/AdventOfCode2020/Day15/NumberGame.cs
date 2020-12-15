using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day15
{
    public class NumberGame
    {
        public IList<int> Numbers { get; }

        public IDictionary<int, int> PreviousIndexOf { get; } // we only care about the last known location, not the entire history

        public NumberGame(IEnumerable<int> numbers)
        {
            Numbers = new List<int>(numbers);
            PreviousIndexOf = new DefaultDictionary<int, int>(_ => 0);

            for (var k = 0; k < Numbers.Count; ++k)
            {
                PreviousIndexOf[Numbers[k]] = k + 1;
            }
        }

        public int Turn()
        {
            var last = Numbers.Last(); // get the last number generated
            var age = 0; // default the age to 0

            if (PreviousIndexOf.TryGetValue(last, out var previousIndex)) // if we've seen it, grab the previous index
            {
                age = Numbers.Count - previousIndex; // generate its age
            }

            PreviousIndexOf[last] = Numbers.Count; // record or update its last known location to here
            Numbers.Add(age); // add the new number to the list (crucially, do not record or update its location, that will happen next loop)

            return age;
        }
    }
}
