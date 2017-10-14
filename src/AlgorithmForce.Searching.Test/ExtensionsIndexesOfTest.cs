using Xunit;
using Xunit.Abstractions;

namespace AlgorithmForce.Searching.Test
{
    public class ExtensionsIndexesOfTest
    {
        private readonly ITestOutputHelper _output;

        public ExtensionsIndexesOfTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void TestCaseDefault()
        {
            var s = string.Concat("Vrogros, the Underlord, is a melee strength hero ",
                "whose commanding presence is crucial to his team's success. ",
                "With his long-lasting abilities, Underlord is able to ",
                "control wide areas of the battlefield during teamfights.");
            var t = new[] { 'U', 'n', 'd', 'e', 'r', 'l', 'o', 'r', 'd' };
            var expected = new[] { 13, 142 };

            Assert.Equal(expected, s.IndexesOf(t));
        }

        [Fact]
        public void TestCaseWithOverlapped()
        {
            var s = "1231abcdabcd123231abcdabcdabcdtrefabc";
            var t = "abcdabcd";
            var expected = new[] { 4, 18, 22 };

            Assert.Equal(expected, s.IndexesOf(t.AsReadOnlyList()));
        }

        [Fact]
        public void TestCaseWithStartIndex()
        {
            var s = string.Concat("Vrogros, the Underlord, is a melee strength hero ",
                "whose commanding presence is crucial to his team's success. ",
                "With his long-lasting abilities, Underlord is able to ",
                "control wide areas of the battlefield during teamfights.");
            var t = new[] { 'U', 'n', 'd', 'e', 'r', 'l', 'o', 'r', 'd' };
            var expected = new[] { 142 };

            Assert.Equal(expected, s.IndexesOf(t, 100));
        }

        [Fact]
        public void TestCaseNotFound()
        {
            var s = string.Concat("Vrogros, the Underlord, is a melee strength hero ",
                "whose commanding presence is crucial to his team's success. ",
                "With his long-lasting abilities, Underlord is able to ",
                "control wide areas of the battlefield during teamfights.");
            var t = new[] { 'S', 'u', 'n', ' ', 'W', 'u', 'k', 'o', 'n', 'g' };

            Assert.Empty(s.IndexesOf(t));
        }

        [Fact]
        public void TestCaseWithStartIndexNotFound()
        {
            var s = string.Concat("Vrogros, the Underlord, is a melee strength hero ",
                "whose commanding presence is crucial to his team's success. ",
                "With his long-lasting abilities, Underlord is able to ",
                "control wide areas of the battlefield during teamfights.");
            var t = new[] { 'U', 'n', 'd', 'e', 'r', 'l', 'o', 'r', 'd' };

            Assert.Empty(s.IndexesOf(t, 180));
        }
    }
}
