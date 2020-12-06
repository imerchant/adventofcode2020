using AdventOfCode2020.Day06;
using AdventOfCode2020.Inputs;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2020.Tests
{
    public class Day06Solutions : TestBase
    {
        public Day06Solutions(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Puzzle1And2_CountUniqueAnswers_AndUnanimousAnswers()
        {
            var forms = new Forms(Input.Day06);

            forms.UniqueYesAnswers.Should().Be(6903);
            forms.UnanimousYesAnswers.Should().Be(3493);
        }

        public const string PuzzleExample =
@"abc

a
b
c

ab
ac

a
a
a
a

b";

        [Fact]
        public void PuzzleExample_CountsGroups_AndAnswersCorrectly()
        {
            var forms = new Forms(PuzzleExample);

            forms.Groups.Should().HaveCount(5);
            forms.UniqueYesAnswers.Should().Be(11);
            forms.UnanimousYesAnswers.Should().Be(6);
        }
    }
}
