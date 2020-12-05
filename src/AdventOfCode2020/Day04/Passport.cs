using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day04
{
    public class Passport
    {
        public static readonly List<string> RequiredFields = new List<string>
        {
            "byr:",
            "iyr:",
            "eyr:",
            "hgt:",
            "hcl:",
            "ecl:",
            "pid:"
        };

        public string Content { get; }
        public bool HasRequiredFields { get; }
        public bool HasValidValues { get; }

        public Passport(string content)
        {
            Content = content;

            HasRequiredFields = RequiredFields
                .All(x => Content.Contains(x, StringComparison.OrdinalIgnoreCase));

            HasValidValues = PassportValidation.AreValuesValid(Content);
        }
    }
}