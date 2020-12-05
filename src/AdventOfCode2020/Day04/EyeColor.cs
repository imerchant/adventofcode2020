using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day04
{
    public class EyeColor : IPassportValidation
    {
        public static readonly Regex Format = new Regex(@"ecl:(?:amb|blu|brn|gry|grn|hzl|oth)", RegexOptions.Compiled);

        public bool IsValid(string content) => Format.IsMatch(content);
    }
}