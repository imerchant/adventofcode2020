using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day16
{
    public class Field
    {
        public static readonly Regex Format = new Regex(@"(?'name'.+): (?'low1'\d+)-(?'high1'\d+) or (?'low2'\d+)-(?'high2'\d+)", RegexOptions.Compiled);

        public string Name { get; }

        public int Low1 { get; }
        public int High1 { get; }

        public int Low2 { get; }
        public int High2 { get; }

        public int Index => Indices.Count == 1 ? Indices.First() : -1;

        public List<int> Indices { get; }

        public Field(string content)
        {
            var match = Format.Match(content);

            Name = match.Groups["name"].Value;
            Low1 = int.Parse(match.Groups["low1"].Value);
            High1 = int.Parse(match.Groups["high1"].Value);
            Low2 = int.Parse(match.Groups["low2"].Value);
            High2 = int.Parse(match.Groups["high2"].Value);
            Indices = new List<int>();
        }

        public bool IsValid(int value) => value >= Low1 && value <= High1 || value >= Low2 && value <= High2;

        public override int GetHashCode() => Name.GetHashCode();

        public override bool Equals(object obj) => obj is Field field && field.Name == Name;

        public override string ToString() => $"{Name} ({Index})";
    }
}