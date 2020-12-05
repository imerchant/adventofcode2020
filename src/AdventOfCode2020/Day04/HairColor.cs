using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day04
{
    public class HairColor : IPassportValidation
    {
        public static readonly Regex Format = new Regex(@"hcl:#[0-9a-f]{6}", RegexOptions.Compiled);

        public bool IsValid(string content) => Format.IsMatch(content);
    }
}