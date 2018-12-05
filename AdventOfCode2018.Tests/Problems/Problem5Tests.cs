namespace AdventOfCode2018.Tests.Problems
{
    using AdventOfCode2018.Problems;

    using NUnit.Framework;

    [TestFixture]
    public class Problem5Tests
    {
        [Test]
        public void TinyTest()
        {
            Assert.AreEqual(0, Problem5.PerformReaction("aA"));
            Assert.AreEqual(0, Problem5.PerformReaction("abBA"));
            Assert.AreEqual(4, Problem5.PerformReaction("abAB"));
            Assert.AreEqual(6, Problem5.PerformReaction("aabAAB"));
        }

        [Test]
        public void BigTest()
        {
            Assert.AreEqual(10, Problem5.PerformReaction("dabAcCaCBAcCcaDA"));
        }

        [Test]
        public void ReductionTest()
        {
            Assert.AreEqual(4, Problem5.FindBestReduction("dabAcCaCBAcCcaDA"));
        }
    }
}
