using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace AlgorithmForce.Searching.Test
{
    public class ExtensionsTest
    {
        private readonly ITestOutputHelper _output;

        public ExtensionsTest(ITestOutputHelper output)
        {
            this._output = output;
        }

        [Fact]
        public void TestCaseList()
        {
            var s = Enumerable.Range(0, 100).ToList();
            var t = new[] { 5, 6, 7, 8, 9 };

            Assert.Equal(5, s.IndexOf(t));
        }

        [Fact]
        public void TestCaseListWithStartIndex()
        {
            var s = Enumerable.Range(0, 100).ToList();
            var t = new[] { 10, 11, 12, 13, 14 };

            Assert.Equal(10, s.IndexOf(t, 10));
        }

        [Fact]
        public void TestCaseListNotFound()
        {
            var s = Enumerable.Range(0, 100).ToList();
            var t = new[] { 8, 10, 12, 12, 14 };

            Assert.Equal(-1, s.IndexOf(t));
        }

        [Fact]
        public void TestCaseListWithStartIndexNotFound()
        {
            var s = Enumerable.Range(0, 100).ToList();
            var t = new[] { 15, 16, 17, 18, 19 };

            Assert.Equal(-1, s.IndexOf(t, 17));
        }

        [Fact]
        public void TestCaseSingleElement()
        {
            var s = @"Vr";
            var t = new[] { 'r' };

            Assert.Equal(1, s.IndexOf(t));
        }
        
        [Fact]
        public void TestCaseString()
        {
            var s = @"Vrogros, the Underlord, is a melee strength hero 
                whose commanding presence is crucial to his team's success.
                With his long-lasting abilities, Underlord is able to 
                control wide areas of the battlefield during teamfights.";
            var t = new[] { 'U', 'n', 'd', 'e', 'r', 'l', 'o', 'r', 'd' };

            Assert.Equal(13, s.IndexOf(t));
        }

        [Fact]
        public void TestCaseStringWithStartIndex()
        {
            var s = @"Vrogros, the Underlord, is a melee strength hero 
                whose commanding presence is crucial to his team's success.
                With his long-lasting abilities, Underlord is able to 
                control wide areas of the battlefield during teamfights.";
            var t = new[] { 't', 'e', 'a', 'm', 'f', 'i', 'g', 'h', 't', 's' };

            Assert.Equal(261, s.IndexOf(t, 128));
        }
        
        [Fact]
        public void TestCaseStringNotFound()
        {
            var s = @"Vrogros, the Underlord, is a melee strength hero 
                whose commanding presence is crucial to his team's success.
                With his long-lasting abilities, Underlord is able to 
                control wide areas of the battlefield during teamfights.";
            var t = new[] { 'S', 'u', 'n', ' ', 'W', 'u', 'k', 'o', 'n', 'g' };

            Assert.Equal(-1, s.IndexOf(t));
        }

        [Fact]
        public void TestCaseStringWithStartIndexNotFound()
        {
            var s = @"Vrogros, the Underlord, is a melee strength hero 
                whose commanding presence is crucial to his team's success.
                With his long-lasting abilities, Underlord is able to 
                control wide areas of the battlefield during teamfights.";
            var t = new[] { 'V', 'r', 'o', 'g', 'r', 'o', 's' };

            Assert.Equal(-1, s.IndexOf(t, 128));
        }
    }
}
