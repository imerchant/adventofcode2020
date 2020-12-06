using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day06
{
    public class Forms : IEnumerable<Group>
    {
        public List<Group> Groups { get; }

        public int UniqueYesAnswers => Groups.Sum(x => x.UniqueYesAnswers);

        public Forms(string input)
        {
            Groups = new List<Group>();
            var lines = input.SplitLines(trimEnds: false);

            var group = new List<string>();
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    Groups.Add(new Group(group));
                    group.Clear();
                }
                else
                {
                    group.Add(line);
                }
            }

            Groups.Add(new Group(group));
        }

        public IEnumerator<Group> GetEnumerator() => Groups.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
