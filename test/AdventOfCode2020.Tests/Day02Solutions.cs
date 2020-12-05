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
        public void Puzzle1_CountValidPasswords_ByCount()
        {
            var input = Input.Day02Parse(Input.Day02);

            var passwords = new Passwords(input);

            passwords.Where(x => x.IsValidByCount).Should().HaveCount(572);
        }

        [Fact]
        public void Puzzle2_CountValidPasswords_ByPosition()
        {
            var input = Input.Day02Parse(Input.Day02);

            var passwords = new Passwords(input);

            passwords.Where(x => x.IsValidByPosition).Should().HaveCount(306);
        }

        public const string PuzzleExample =
@"1-3 a: abcde
1-3 b: cdefg
2-9 c: ccccccccc";

        [Fact]
        public void Puzzle1_Example_CountsValidPasswords_ByCountCorrectly()
        {
            var input = Input.Day02Parse(PuzzleExample);

            var passwords = new Passwords(input);

            passwords.Where(x => x.IsValidByCount).Should().HaveCount(2);
        }

        [Fact]
        public void Puzzle2_ExampleCountsValidPasswords_ByPositionCorrectly()
        {
            var input = Input.Day02Parse(PuzzleExample);

            var passwords = new Passwords(input);

            passwords.Where(x => x.IsValidByPosition).Should().HaveCount(1);
        }
    }
}
