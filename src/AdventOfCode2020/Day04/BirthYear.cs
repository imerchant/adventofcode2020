using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day04
{
    public class BirthYear : IPassportValidation
    {
        public static readonly Regex Format = new Regex(@"byr:(?'year'\d{4})", RegexOptions.Compiled);

        public bool IsValid(string content)
        {
            var match = Format.Match(content);

            if (!match.Success) return false;

            var year = int.Parse(match.Groups["year"].Value);

            return year >= 1920 && year <= 2002;
        }
    }
}