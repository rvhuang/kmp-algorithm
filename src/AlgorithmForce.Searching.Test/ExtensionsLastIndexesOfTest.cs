using Xunit;
using Xunit.Abstractions;

namespace AlgorithmForce.Searching.Test
{
    public class ExtensionsLastIndexesOfTest
    {
        private readonly ITestOutputHelper _output;

        public ExtensionsLastIndexesOfTest(ITestOutputHelper output)
        {
            this._output = output;
        }

        [Fact]
        public void TestCaseDefault()
        {
            var s = @"Vrogros, the Underlord, is a melee strength hero 
                whose commanding presence is crucial to his team's success.
                With his long-lasting abilities, Underlord is able to 
                control wide areas of the battlefield during teamfights.";
            var t = new[] { 'U', 'n', 'd', 'e', 'r', 'l', 'o', 'r', 'd' };
            var expected = new[] { 177, 13 };

            Assert.Equal(expected, s.LastIndexesOf(t));
        }

        [Fact]
        public void TestCaseWithOverlapped()
        {
            var s = "1231abcdabcd123231abcdabcdabcdtrefabc";
            var t = "abcdabcd";
            var expected = new[] { 22, 18, 4 };

            Assert.Equal(expected, s.LastIndexesOf(t.AsReadOnlyList()));
        }

        [Fact]
        public void TestCaseWithStartIndex()
        {
            var s = @"Vrogros, the Underlord, is a melee strength hero 
                whose commanding presence is crucial to his team's success.
                With his long-lasting abilities, Underlord is able to 
                control wide areas of the battlefield during teamfights.";
            var t = new[] { 'U', 'n', 'd', 'e', 'r', 'l', 'o', 'r', 'd' };
            var expected = new[] { 13 };

            Assert.Equal(expected, s.LastIndexesOf(t, 177));
        }

        [Fact]
        public void TestCaseNotFound()
        {
            var s = @"Vrogros, the Underlord, is a melee strength hero 
                whose commanding presence is crucial to his team's success.
                With his long-lasting abilities, Underlord is able to 
                control wide areas of the battlefield during teamfights.";
            var t = new[] { 'S', 'u', 'n', ' ', 'W', 'u', 'k', 'o', 'n', 'g' };

            Assert.Empty(s.LastIndexesOf(t));
        }

        [Fact]
        public void TestCaseWithStartIndexNotFound()
        {
            var s = @"Vrogros, the Underlord, is a melee strength hero 
                whose commanding presence is crucial to his team's success.
                With his long-lasting abilities, Underlord is able to 
                control wide areas of the battlefield during teamfights.";
            var t = new[] { 'U', 'n', 'd', 'e', 'r', 'l', 'o', 'r', 'd' };

            Assert.Empty(s.LastIndexesOf(t, 13));
        }
    }
}
