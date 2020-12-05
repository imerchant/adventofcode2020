using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day02
{
    public class Password
    {
        public static readonly Regex Format = new Regex(@"(?'min'\d+)-(?'max'\d+) (?'char'\w): (?'content'\w+)", RegexOptions.Compiled);

        public string Content { get; }
        public bool IsValidByCount { get; }
        public bool IsValidByPosition { get; }

        public char PolicyChar { get; }
        public int Param1 { get; } // minimum when by count
        public int Param2 { get; } // maximum when by count

        public Password(string password)
        {
            var parsed = Format.Match(password);

            Param1 = int.Parse(parsed.Groups["min"].Value);
            Param2 = int.Parse(parsed.Groups["max"].Value);
            PolicyChar = parsed.Groups["char"].Value[0];
            Content = parsed.Groups["content"].Value;

            var count = Content.Count(x => x == PolicyChar);
            IsValidByCount = count >= Param1 && count <= Param2;

            IsValidByPosition = (Content[Param1 - 1] == PolicyChar) ^ (Content[Param2 - 1] == PolicyChar); // xor AND non-zero indexes, in the same problem? madness.
        }
    }
}