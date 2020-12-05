using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day04
{
    public class PassportId : IPassportValidation
    {
        public static readonly Regex Format = new Regex(@"pid:(\d{9})\b", RegexOptions.Compiled); // \b so we don't include longer ones, and not \s because it could be at the very end of the string

        public bool IsValid(string content) => Format.IsMatch(content);
    }
}