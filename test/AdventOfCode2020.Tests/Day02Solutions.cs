using System.Linq;
using AdventOfCode2020.Day02;
using AdventOfCode2020.Inputs;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2020.Tests
{
    public class Day02Solutions : TestBase
    {
        public Day02Solutions(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Puzzle1_CountValidPasswords()
        {
            var input = Input.Day02Parse(Input.Day02);

            var passwords = new Passwords(input);

            passwords.Count(x => x.IsValid).Should().Be(572);
        }

        public const string Puzzle1Example =
@"1-3 a: abcde
1-3 b: cdefg
2-9 c: ccccccccc";

        [Fact]
        public void Puzzle1Example_CountsValidPasswordsCorrectly()
        {
            var input = Input.Day02Parse(Puzzle1Example);

            var passwords = new Passwords(input);

            passwords.Count(x => x.IsValid).Should().Be(2);
        }
    }
}
