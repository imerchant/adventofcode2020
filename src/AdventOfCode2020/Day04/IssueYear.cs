using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day04
{
    public class IssueYear : IPassportValidation
    {
        public static readonly Regex Format = new Regex(@"iyr:(?'year'\d{4})", RegexOptions.Compiled);

        public bool IsValid(string content)
        {
            var match = Format.Match(content);

            if (!match.Success) return false;

            var year = int.Parse(match.Groups["year"].Value);

            return year >= 2010 && year <= 2020;
        }
    }
}