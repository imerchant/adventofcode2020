using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day06
{
    public class Group
    {
        public List<string> Answers { get; }

        public HashSet<char> UniqueYesAnswers { get; }

        public int UnanimousYesAnswersCount { get; }

        public Group(IEnumerable<string> input)
        {
            Answers = new List<string>(input);

            UniqueYesAnswers = Answers.SelectMany(x => x).ToHashSet();

            UnanimousYesAnswersCount = UniqueYesAnswers.Count(answer => Answers.All(x => x.Contains(answer)));
        }
    }
}