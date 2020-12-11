using AdventOfCode2020.Day10;
using AdventOfCode2020.Inputs;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2020.Tests
{
    public class Day10Solutions : TestBase
    {
        public Day10Solutions(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Puzzle1And2_FindProductOfDifferencesOf1AndOf3_AndPermutations()
        {
            var adapters = new JoltageAdapters(Input.Day10);

            var (of1, of3) = adapters.GetDifferences();

            (of1 * of3).Should().Be(2432);
            adapters.Permutations.Should().Be(453551299002368L);
        }

        public const string Example1 =
@"16
10
15
5
1
11
7
19
6
12
4";

        [Fact]
        public void Example1_Adapters_AreUpdatedAndSortedProperly()
        {
            var adapters = new JoltageAdapters(Example1);

            adapters.Should().HaveCount(13).And.BeInAscendingOrder().And.StartWith(0).And.EndWith(22);

            adapters.GetDifferences().Should().Be((7, 5));
            adapters.Permutations.Should().Be(8L);
        }

        public const string Example2 =
@"28
33
18
42
31
14
46
20
48
47
24
23
49
45
19
38
39
11
1
32
25
35
8
17
7
9
4
2
34
10
3";

        [Fact]
        public void Example2_FindsDifferencesCorrectly()
        {
            var adapters = new JoltageAdapters(Example2);

            adapters.GetDifferences().Should().Be((22, 10));
            adapters.Permutations.Should().Be(19208L);
        }
    }
}
