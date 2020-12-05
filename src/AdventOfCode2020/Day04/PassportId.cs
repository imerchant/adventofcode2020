using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day04
{
    public class PassportId : IPassportValidation
    {
        public static readonly Regex Format = new Regex(@"pid:(\d{9})\b", RegexOptions.Compiled);

        public bool IsValid(string content) => Format.IsMatch(content);
    }
}