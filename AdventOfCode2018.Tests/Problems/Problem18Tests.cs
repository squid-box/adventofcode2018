namespace AdventOfCode2018.Tests.Problems
{
    using NUnit.Framework;

    using AdventOfCode2018.Problems;

    [TestFixture]
    public class Problem18Tests
    {
        private static readonly string[] TestInput =
        {
            ".#.#...|#.",
            ".....#|##|",
            ".|..|...#.",
            "..|#.....#",
            "#.#|||#|#|",
            "...#.||...",
            ".|....|...",
            "||...#|.#|",
            "|.||||..|.",
            "...#.|..|."
        };

        [Test]
        public void InputParsingTest()
        {
            var parsedInput = new LumberCollectionArea(TestInput);

            Assert.AreEqual(10, parsedInput.Height);
            Assert.AreEqual(10, parsedInput.Width);

            Assert.AreEqual(Acre.Lumberyard, parsedInput.Acres[1,0]);
            Assert.AreEqual(Acre.Open, parsedInput.Acres[3, 1]);
            Assert.AreEqual(Acre.Trees, parsedInput.Acres[8, 9]);
        }

        [Test]
        public void FindResourceValueTest()
        {
            var parsedInput = new LumberCollectionArea(TestInput);

            Assert.AreEqual(17 * 27, parsedInput.ResourceValue);
            
            parsedInput.Iterate(1);

            Assert.AreEqual(12 * 40, parsedInput.ResourceValue);

            parsedInput.Iterate(9);

            Assert.AreEqual(37 * 31, parsedInput.ResourceValue);
        }

        [Test]
        public void IterateLumberyardTest()
        {
            var parsedInput = new LumberCollectionArea(TestInput);

            Assert.AreEqual(Acre.Lumberyard, parsedInput.Acres[1, 0]);
            Assert.AreEqual(Acre.Open, parsedInput.Acres[3, 1]);
            Assert.AreEqual(Acre.Trees, parsedInput.Acres[8, 9]);

            parsedInput.Iterate(1);

            Assert.AreEqual(Acre.Open, parsedInput.Acres[1, 0]);
            Assert.AreEqual(Acre.Open, parsedInput.Acres[3, 1]);
            Assert.AreEqual(Acre.Trees, parsedInput.Acres[8, 9]);
        }

        [Test]
        public void LumberCollectionYardTest()
        {
            var input1 = new LumberCollectionArea(TestInput);
            var input2 = new LumberCollectionArea(TestInput);

            Assert.AreEqual(input1, input2);
            Assert.AreEqual(input1.GetHashCode(), input2.GetHashCode());

            input2.Iterate(1);

            Assert.AreNotEqual(input1, input2);
            Assert.AreNotEqual(input1.GetHashCode(), input2.GetHashCode());
        }
    }
}
