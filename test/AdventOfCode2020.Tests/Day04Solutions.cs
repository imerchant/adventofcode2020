using System.Linq;
using AdventOfCode2020.Day04;
using AdventOfCode2020.Inputs;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2020.Tests
{
    public class Day04Solutions : TestBase
    {
        public Day04Solutions(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Puzzle1_CountValidPassports_IgnoringCountryId()
        {
            var passports = new Passports(Input.Day04);

            passports.Count(x => x.IsValid).Should().Be(206);
        }

        public const string PuzzleExample =
@"ecl:gry pid:860033327 eyr:2020 hcl:#fffffd
byr:1937 iyr:2017 cid:147 hgt:183cm

iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884
hcl:#cfa07d byr:1929

hcl:#ae17e1 iyr:2013
eyr:2024
ecl:brn pid:760753108 byr:1931
hgt:179cm

hcl:#cfa07d eyr:2025 pid:166559648
iyr:2011 ecl:brn hgt:59in";

        [Fact]
        public void PuzzleExample_CountsPasswordsCorrectly()
        {
            var passports = new Passports(PuzzleExample);

            passports.Should().HaveCount(4);
            passports.Count(x => x.IsValid).Should().Be(2);
        }
    }
}
