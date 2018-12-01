using System.Collections.Generic;
using AdventOfCode2018.Problems;

namespace AdventOfCode2018.Tests.Problems
{
    using NUnit.Framework;

    [TestFixture]
    public class Problem1Tests
    {
		[Test]
	    public void TestFindResultingFrequency()
	    {
		    var testInput1 = new List<string>
		    {
				"+1",
				"+1",
				"+1"
		    };

			var testInput2 = new List<string>
			{
				"+1",
				"+1",
				"-2"
			};

			var testInput3 = new List<string>
			{
				"-1",
				"-2",
				"-3"
			};

			Assert.AreEqual(3, Problem1.FindResultingFrequency(testInput1));
		    Assert.AreEqual(0, Problem1.FindResultingFrequency(testInput2));
		    Assert.AreEqual(-6, Problem1.FindResultingFrequency(testInput3));
		}

	    [Test]
	    public void TestFindRepeatingFrequency()
	    {
		    var testInput1 = new List<string>
		    {
			    "+1",
			    "-1"
		    };

		    var testInput2 = new List<string>
		    {
			    "+3",
			    "+3",
			    "+4",
				"-2",
				"-4"
		    };

		    var testInput3 = new List<string>
		    {
			    "-6",
			    "+3",
			    "+8",
				"+5",
				"-6"
		    };

		    var testInput4 = new List<string>
		    {
			    "+7",
			    "+7",
			    "-2",
				"-7",
				"-4"
		    };

			Assert.AreEqual(0, Problem1.FindFirstRepeatingFrequency(testInput1));
		    Assert.AreEqual(10, Problem1.FindFirstRepeatingFrequency(testInput2));
		    Assert.AreEqual(5, Problem1.FindFirstRepeatingFrequency(testInput3));
		    Assert.AreEqual(14, Problem1.FindFirstRepeatingFrequency(testInput4));
		}
    }
}
