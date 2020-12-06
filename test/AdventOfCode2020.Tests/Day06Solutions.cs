using System;
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
        public void Puzzle1_CountUniqueAnswersFromUniqueGroups()
        {
            var forms = new Forms(Input.Day06);

            forms.UniqueYesAnswers.Should().Be(6903);
        }

        public const string Puzzle1Example =
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
        public void Puzzle1Example_CountsGroups_AndAnswersCorrectly()
        {
            var forms = new Forms(Puzzle1Example);

            forms.Should().HaveCount(5);
            forms.UniqueYesAnswers.Should().Be(11);
        }
    }
}
