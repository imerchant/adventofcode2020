using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day06
{
    public class Forms
    {
        public List<Group> Groups { get; }

        public int UniqueYesAnswers => Groups.Sum(x => x.UniqueYesAnswers.Count);

        public int UnanimousYesAnswers => Groups.Sum(x => x.UnanimousYesAnswersCount);

        public Forms(string input)
        {
            Groups = new List<Group>();
            var lines = input.SplitLines(removeEmptyEntries: false);

            var group = new List<string>();
            foreach (var line in lines) // this is much easier than the regex nonsense I did for the passports for Day 4
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
    }
}
