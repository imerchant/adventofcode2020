using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day04
{
    public class Height : IPassportValidation
    {
        public static readonly Regex Format = new Regex(@"hgt:(?'height'\d+)(?'unit'in|cm)", RegexOptions.Compiled);

        public bool IsValid(string content)
        {
            var match = Format.Match(content);

            if (!match.Success) return false;

            var unit = match.Groups["unit"].Value;
            var height = int.Parse(match.Groups["height"].Value);

            return unit switch
            {
                "in" => height >= 59 && height <= 76,
                "cm" => height >= 150 && height <= 193,
                _ => false
            };
        }
    }
}