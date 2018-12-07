using AdventOfCode2018.Problems;

namespace AdventOfCode2018.Tests.Problems
{
    using NUnit.Framework;

    [TestFixture]
    public class Problem6Tests
    {
        private static readonly string[] TestInput =
        {
            "1, 1",
            "1, 6",
            "8, 3",
            "3, 4",
            "5, 5",
            "8, 9"
        };

        [Test]
        public void ParseInputTest()
        {
            var coordinates = Problem6.ParseInput(TestInput);
            Assert.AreEqual(6, coordinates.Count);
        }

        [Test]
        public void FindLargestAreaTest()
        {
            var coordinates = Problem6.ParseInput(TestInput);
            Assert.AreEqual(17, Problem6.FindLargestArea(coordinates));
        }

        [Test]
        public void FindSizeOfSafeRegionTest()
        {
            var coordinates = Problem6.ParseInput(TestInput);
            Assert.AreEqual(16, Problem6.FindSizeOfSafeRegion(coordinates));
        }
    }
}
