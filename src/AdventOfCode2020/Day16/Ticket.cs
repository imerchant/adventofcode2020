using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day16
{
    public class Ticket : IEnumerable<int>
    {
        public int this[int i] => Values[i];

        public int Count => Values.Count;

        public IList<int> Values { get; }
        
        public int ErrorRate { get; }

        public bool IsValid { get; }

        public Ticket(IEnumerable<int> values, IList<Field> fields)
        {
            Values = new List<int>(values);

            ErrorRate = 0;
            IsValid = true;
            foreach (var value in Values)
            {
                if (fields.All(field => !field.IsValid(value)))
                {
                    ErrorRate += value;
                    IsValid = false;
                }
            }
        }

        public IEnumerator<int> GetEnumerator() => Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}