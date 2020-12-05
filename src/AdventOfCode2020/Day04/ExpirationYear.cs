using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day04
{
    public class ExpirationYear : IPassportValidation
    {
        public static readonly Regex Format = new Regex(@"eyr:(?'year'\d{4})", RegexOptions.Compiled);

        public bool IsValid(string content)
        {
            var match = Format.Match(content);

            if (!match.Success) return false;

            var year = int.Parse(match.Groups["year"].Value);

            return year is >= 2020 and <= 2030; // only works with constants
        }
    }
}