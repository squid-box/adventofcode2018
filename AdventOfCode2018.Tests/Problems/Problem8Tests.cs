namespace AdventOfCode2018.Tests.Problems
{
    using AdventOfCode2018.Problems;

    using NUnit.Framework;

    [TestFixture]
    public class Problem8Tests
    {
	    private static readonly string TestInput = "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2";

        [Test]
        public void ParseInputTest()
        {
	        var rootNode = Problem8.ParseInput(TestInput);

			Assert.AreEqual(2, rootNode.Children.Count);
	        Assert.AreEqual(3, rootNode.Metadata.Count);
		}
    }
}
