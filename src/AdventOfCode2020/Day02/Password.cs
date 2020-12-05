using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day02
{
    public class Password
    {
        public static readonly Regex Format = new Regex(@"(?'min'\d+)-(?'max'\d+) (?'char'\w): (?'content'\w+)");

        public string Content { get; }
        public bool IsValid { get; }

        public char PolicyChar { get; }
        public int Minimum { get; }
        public int Maximum { get; }

        public Password(string password)
        {
            var parsed = Format.Match(password);

            Minimum = int.Parse(parsed.Groups["min"].Value);
            Maximum = int.Parse(parsed.Groups["max"].Value);
            PolicyChar = parsed.Groups["char"].Value[0];
            Content = parsed.Groups["content"].Value;

            var count = Content.Count(x => x == PolicyChar);
            IsValid = count >= Minimum && count <= Maximum;
        }
    }
}