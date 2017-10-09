using Xunit.Abstractions;

namespace AlgorithmForce.Searching.Test
{
    public abstract class ExtensionsTest
    {
        private readonly ITestOutputHelper _output;

        protected ITestOutputHelper Output => _output;

        public ExtensionsTest(ITestOutputHelper output)
        {
            _output = output;
        }

        public abstract void TestCaseList();
         
        public abstract void TestCaseListWithStartIndex();
         
        public abstract void TestCaseListNotFound();
         
        public abstract void TestCaseListWithStartIndexNotFound();

        public abstract void TestCaseSingleElement();

        public abstract void TestCaseString();

        public abstract void TestCaseStringWithStartIndex();

        public abstract void TestCaseStringNotFound();

        public abstract void TestCaseStringWithStartIndexNotFound();
    }
}
