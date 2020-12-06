using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day06
{
    public class Group
    {
        public List<string> Answers { get; }

        public int UniqueYesAnswers => Answers.SelectMany(x => x).Distinct().Count();

        public Group(IEnumerable<string> input)
        {
            Answers = input.Select(x => x.Trim()).ToList();
        }
    }
}