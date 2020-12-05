using System;
using System.Collections.Generic;

namespace AdventOfCode2020.Day01
{
    public class ExpenseReport
    {
        public List<int> Entries { get; }

        public ExpenseReport(IEnumerable<int> entries)
        {
            Entries = new List<int>(entries);
        }

        public int Find2020PairAndMultiply()
        {
            for (var k = 0; k < Entries.Count; ++k)
            {
                for (var j = 0; j < Entries.Count; ++j)
                {
                    if (k == j) continue;

                    if (Entries[k] + Entries[j] == 2020)
                        return Entries[k] * Entries[j];
                }
            }

            throw new Exception("Could not locate pair that adds to 2020");
        }

        public long Find2020TripletAndMultiply()
        {
            for (var k = 0; k < Entries.Count; ++k)
            {
                for (var j = 0; j < Entries.Count; ++j)
                {
                    for (var i = 0; i < Entries.Count; ++i)
                    {
                        if (k == j || k == i || j == i) continue;

                        if (Entries[k] + Entries[j] + Entries[i] == 2020)
                            return Entries[k] * Entries[j] * Entries[i];
                    }
                    
                }
            }

            throw new Exception("Could not locate triplets that add to 2020");
        }
    }
}
