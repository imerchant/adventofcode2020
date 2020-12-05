using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day04
{
    public static class PassportValidation
    {
        public static readonly List<IPassportValidation> Validations = new List<IPassportValidation>
        {
            new BirthYear(),
            new IssueYear(),
            new ExpirationYear(),
            new Height(),
            new HairColor(),
            new EyeColor(),
            new PassportId()
        };

        public static bool AreValuesValid(string content)
        {
            return Validations.All(x => x.IsValid(content)); // strategy pattern lol
        }
    }
}