using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day07
{
    public class Bags
    {
        public const string ShinyGold = "shiny gold";
        public static readonly Regex NoOtherBags = new Regex(@"(?'description'\w+? \w+?) bags contain no other bags", RegexOptions.Compiled);
        public static readonly Regex HasOtherBags = new Regex(@"(?:(?'count'\d) )*(?'description'\w+? \w+?) bags*", RegexOptions.Compiled);

        public Bag this[string description] => Entries[description];

        public IDictionary<string, Bag> Entries { get; }

        public Bags(string input)
        {
            Entries = new DefaultDictionary<string, Bag>(description => new Bag(description));

            foreach (var line in input.SplitLines())
            {
                Bag thisBag = null;
                string description;
                var noOtherBagsMatch = NoOtherBags.Match(line);
                if (noOtherBagsMatch.Success)
                {
                    description = noOtherBagsMatch.Groups["description"].Value;
                    thisBag = new Bag(description);
                    Entries[description] = thisBag;
                    continue;
                }

                foreach (Match match in HasOtherBags.Matches(line))
                {
                    description = match.Groups["description"].Value;
                    if (thisBag is null)
                    {
                        thisBag = Entries[description];
                        continue;
                    }

                    var someOtherBag = Entries[description];
                    var count = int.Parse(match.Groups["count"].Value);
                    someOtherBag.ContainedBy.Add(thisBag);
                    thisBag.Contains.Add((someOtherBag, count));
                }
            }
        }

        public int CountShinyGoldParents()
        {
            var parents = new HashSet<Bag>();
            var investigating = new Stack<Bag>();
            investigating.Push(Entries[ShinyGold]);

            do
            {
                var bag = investigating.Pop();
                foreach (var otherBag in bag.ContainedBy)
                {
                    investigating.Push(otherBag);
                    parents.Add(otherBag);
                }
            } while (investigating.TryPeek(out _));

            return parents.Count;
        }

        public int CountShinyGoldChildren()
        {
            return Entries[ShinyGold].CountChildren() - 1; // minus 1 because we don't want to count the shiny gold bag itself
        }
    }
}
