using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace AlgorithmForce.Searching.Test
{
    using Deferred;

    public class EnumerableExtensionsTest
    {        
        private readonly ITestOutputHelper _output;

        public EnumerableExtensionsTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void TestCaseEnumerableIndexOf()
        {            
            var s = Enumerable.Range(0, 100);
            var t = new[] { 95, 96, 97, 98, 99 };

            Assert.Equal(95, EnumerableExtensions.IndexOf(s, t, 0, null));
        }

        [Fact]
        public void TestCaseEnumerableIndexOfNotFound()
        {            
            var s = Enumerable.Range(0, 100);
            var t = new[] { 90, 92, 94, 96, 98 };

            Assert.Equal(-1, EnumerableExtensions.IndexOf(s, t, 0, null));
        }

        [Fact]
        public void TestCaseEnumerableIndexOfWithTextReader()
        {
            var s = string.Concat("Vrogros, the Underlord, is a melee strength hero ", 
                "whose commanding presence is crucial to his team's success. ",
                "With his long-lasting abilities, Underlord is able to ",
                "control wide areas of the battlefield during teamfights.");
            var t = new[] { 'U', 'n', 'd', 'e', 'r', 'l', 'o', 'r', 'd' };

            using (var reader = new StringReader(s))
            {
                Assert.Equal(s.IndexOf(string.Concat(t)), EnumerableExtensions.IndexOf(reader.AsCharEnumerable(), t, 0, null));
            }
        }

        [Fact]
        public void TestCaseEnumerableIndexOfWithTextReaderNotFound()
        {
            var s = string.Concat("Vrogros, the Underlord, is a melee strength hero ", 
                "whose commanding presence is crucial to his team's success. ",
                "With his long-lasting abilities, Underlord is able to ",
                "control wide areas of the battlefield during teamfights.");
            var t = new[] { 'S', 'u', 'n', ' ', 'W', 'u', 'k', 'o', 'n', 'g' };

            using (var reader = new StringReader(s))
            {
                Assert.Equal(s.IndexOf(string.Concat(t)), EnumerableExtensions.IndexOf(reader.AsCharEnumerable(), t, 0, null));
            }
        }

        [Fact]
        public void TestCaseEnumerableIndexOfWithStartIndex()
        {
            var s = Enumerable.Range(0, 100);
            var t = new[] { 95, 96, 97, 98, 99 };

            Assert.Equal(95, EnumerableExtensions.IndexOf(s, t, 20, null));
        }

        [Fact]
        public void TestCaseEnumerableIndexOfWithStartIndexNotFound()
        {
            var s = Enumerable.Range(0, 100);
            var t = new[] { 95, 96, 97, 98, 99 };

            Assert.Equal(-1, EnumerableExtensions.IndexOf(s, t, 97, null));
        }

        [Fact]
        public void TestCaseEnumerableIndexOfWithTextReaderAndStartIndex()
        {
            var s = string.Concat("Vrogros, the Underlord, is a melee strength hero ", 
                "whose commanding presence is crucial to his team's success. ",
                "With his long-lasting abilities, Underlord is able to ",
                "control wide areas of the battlefield during teamfights.");
            var t = new[] { 'U', 'n', 'd', 'e', 'r', 'l', 'o', 'r', 'd' };

            using (var reader = new StringReader(s))
            {
                Assert.Equal(s.IndexOf(string.Concat(t), 160), EnumerableExtensions.IndexOf(reader.AsCharEnumerable(), t, 160, null));
            }
        }

        [Fact]
        public void SkipTest()
        {
            var s = Enumerable.Range(5, 100);

            using (var enumerator = s.GetEnumerator())
            {
                EnumerableExtensions.Skip(enumerator, 55).MoveNext();
                Assert.Equal(s.Skip(55).First(), enumerator.Current);
            }
        }
    }
}