using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day04
{
    public class Passports : IEnumerable<Passport>
    {
        public static readonly Regex Format = new Regex(@"(?:\w{3}:[\w\d#]+)+(?:\s?\w{3}:[\w\d#]+){0,7}", RegexOptions.Compiled | RegexOptions.Multiline);

        public List<Passport> Entries { get; }

        public Passports(string input)
        {
            input = input.Replace("\r\n", "\n"); // I hate line endings, fuck

            Entries = Format.Matches(input).Select(x => new Passport(x.Value)).ToList();
        }

        public IEnumerator<Passport> GetEnumerator() => Entries.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
