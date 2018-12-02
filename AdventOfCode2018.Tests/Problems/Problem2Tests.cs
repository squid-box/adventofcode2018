namespace AdventOfCode2018.Tests.Problems
{
    using AdventOfCode2018.Problems;
    
    using NUnit.Framework;

    [TestFixture]
    public class Problem2Tests
    {
        [Test]
        public void TestContainOccurences()
        {
			Assert.IsFalse(Problem2.ContainsOccurrences("abcdef", 2));
	        Assert.IsFalse(Problem2.ContainsOccurrences("abcdef", 3));

			Assert.IsTrue(Problem2.ContainsOccurrences("bababc", 2));
	        Assert.IsTrue(Problem2.ContainsOccurrences("bababc", 3));

			Assert.IsTrue(Problem2.ContainsOccurrences("abbcde", 2));
	        Assert.IsFalse(Problem2.ContainsOccurrences("abbcde", 3));

			Assert.IsFalse(Problem2.ContainsOccurrences("abcccd", 2));
	        Assert.IsTrue(Problem2.ContainsOccurrences("abcccd", 3));

			Assert.IsTrue(Problem2.ContainsOccurrences("aabcdd", 2));
	        Assert.IsFalse(Problem2.ContainsOccurrences("aabcdd", 3));

			Assert.IsTrue(Problem2.ContainsOccurrences("abcdee", 2));
	        Assert.IsFalse(Problem2.ContainsOccurrences("abcdee", 3));

			Assert.IsFalse(Problem2.ContainsOccurrences("ababab", 2));
	        Assert.IsTrue(Problem2.ContainsOccurrences("ababab", 3));
		}

	    [Test]
	    public void TestCalculateChecksum()
	    {
		    var input = new[]
		    {
				"abcdef",
				"bababc",
				"abbcde",
				"abcccd",
				"aabcdd",
				"abcdee",
				"ababab"
			};

			Assert.AreEqual(12, Problem2.FindChecksum(input));
	    }
    }
}
