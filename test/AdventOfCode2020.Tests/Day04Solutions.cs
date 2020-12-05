using System.Collections.Generic;
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

            passports.Where(x => x.HasRequiredFields).Should().HaveCount(206);
        }

        [Fact]
        public void Puzzle2_CountPassportsWithValidValues_StillIgnoringCountryId()
        {
            var passports = new Passports(Input.Day04);

            passports.Where(x => x.HasValidValues).Should().HaveCount(123);
        }

        public const string Puzzle1Example =
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
        public void Puzzle1Example_CountsPasswordsCorrectly()
        {
            var passports = new Passports(Puzzle1Example);

            passports.Should().HaveCount(4);
            passports.Where(x => x.HasRequiredFields).Should().HaveCount(2);
        }

        public static IEnumerable<object[]> ValidatorsReturnCorrectlyCases()
        {
            yield return new object[] { new BirthYear(), "byr:2002", true };
            yield return new object[] { new BirthYear(), "byr:2003", false };

            yield return new object[] { new Height(), "hgt:60in", true };
            yield return new object[] { new Height(), "hgt:190cm", true };
            yield return new object[] { new Height(), "hgt:190in", false };
            yield return new object[] { new Height(), "hgt:190", false };

            yield return new object[] { new HairColor(), "hcl:#123abc", true };
            yield return new object[] { new HairColor(), "hcl:#123abz", false };
            yield return new object[] { new HairColor(), "hcl:123abc", false };

            yield return new object[] { new EyeColor(), "ecl:brn", true };
            yield return new object[] { new EyeColor(), "ecl:wat", false };

            yield return new object[] { new PassportId(), "pid:000000001", true };
            yield return new object[] { new PassportId(), "pid:0123456789", false };
        }

        [Theory]
        [MemberData(nameof(ValidatorsReturnCorrectlyCases))]
        public void Puzzle2_ValidatorsReturnCorrectly(IPassportValidation validation, string content, bool expectedResult)
        {
            validation.IsValid(content).Should().Be(expectedResult);
        }

        public const string InvalidPassports = 
@"eyr:1972 cid:100
hcl:#18171d ecl:amb hgt:170 pid:186cm iyr:2018 byr:1926

iyr:2019
hcl:#602927 eyr:1967 hgt:170cm
ecl:grn pid:012533040 byr:1946

hcl:dab227 iyr:2012
ecl:brn hgt:182cm pid:021572410 eyr:2020 byr:1992 cid:277

hgt:59cm ecl:zzz
eyr:2038 hcl:74454a iyr:2023
pid:3556412378 byr:2007";

        public const string ValidPassports =
@"pid:087499704 hgt:74in ecl:grn iyr:2012 eyr:2030 byr:1980
hcl:#623a2f

eyr:2029 ecl:blu cid:129 byr:1989
iyr:2014 pid:896056539 hcl:#a97842 hgt:165cm

hcl:#888785
hgt:164cm byr:2001 iyr:2015 cid:88
pid:545766238 ecl:hzl
eyr:2022

iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719";

        [Theory]
        [InlineData(InvalidPassports, false)]
        [InlineData(ValidPassports, true)]
        public void Puzzle2_ExamplesAreAllAsExpected(string content, bool expectedResult)
        {
            var passports = new Passports(content);

            passports.Select(x => x.HasValidValues).Should().AllBeEquivalentTo(expectedResult);
        }
    }
}
