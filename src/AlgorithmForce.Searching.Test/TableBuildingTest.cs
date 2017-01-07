using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace AlgorithmForce.Searching.Test
{
    public class TableBuildingTest
    {
        private readonly ITestOutputHelper _output;

        public TableBuildingTest(ITestOutputHelper output)
        {
            this._output = output;
        }

        [Fact]
        public void TestCase1()
        {
            var input = "abcabx";
            var expected = new[] { -1, 0, 0, 0, 1, 2 };
            var actual = Extensions.BuildTable(input.AsReadOnlyList(), EqualityComparer<char>.Default);
            
            this._output.WriteLine("Expected:\t{0}", string.Join(", ", expected));
            this._output.WriteLine("Actual:\t{0}", string.Join(", ", actual));

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase2()
        {
            var input = "abcdex";
            var expected = new[] { -1, 0, 0, 0, 0, 0 };
            var actual = Extensions.BuildTable(input.AsReadOnlyList(), EqualityComparer<char>.Default);

            this._output.WriteLine("Expected:\t{0}", string.Join(", ", expected));
            this._output.WriteLine("Actual:\t{0}", string.Join(", ", actual));

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase3()
        {
            var input = "ababaaaba";
            var expected = new[] { -1, 0, 0, 1, 2, 3, 1, 1, 2 };
            var actual = Extensions.BuildTable(input.AsReadOnlyList(), EqualityComparer<char>.Default);

            this._output.WriteLine("Expected:\t{0}", string.Join(", ", expected));
            this._output.WriteLine("Actual:\t{0}", string.Join(", ", actual));

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase4()
        {
            var input = "aaaaaaaab";
            var expected = new[] { -1, 0, 1, 2, 3, 4, 5, 6, 7 };
            var actual = Extensions.BuildTable(input.AsReadOnlyList(), EqualityComparer<char>.Default);

            this._output.WriteLine("Expected:\t{0}", string.Join(", ", expected));
            this._output.WriteLine("Actual:\t{0}", string.Join(", ", actual));

            Assert.Equal(expected, actual);
        }
    }
}
