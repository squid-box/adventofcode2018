namespace AdventOfCode2018.Tests.Problems
{
    using System.Collections.Generic;
    
    using NUnit.Framework;

    using AdventOfCode2018.Problems;

    [TestFixture]
    public class Problem18Tests
    {
        private static string[] TestInput =
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

            Assert.AreEqual(17 * 27, Problem18.FindResourceValue(parsedInput));
            
            parsedInput.Iterate();

            Assert.AreEqual(12 * 40, Problem18.FindResourceValue(parsedInput));

            for (var i = 1; i < 10; i++)
            {
                parsedInput.Iterate();
            }

            Assert.AreEqual(37 * 31, Problem18.FindResourceValue(parsedInput));
        }

        [Test]
        public void IterateLumberyardTest()
        {
            var parsedInput = new LumberCollectionArea(TestInput);

            Assert.AreEqual(Acre.Lumberyard, parsedInput.Acres[1, 0]);
            Assert.AreEqual(Acre.Open, parsedInput.Acres[3, 1]);
            Assert.AreEqual(Acre.Trees, parsedInput.Acres[8, 9]);

            parsedInput.Iterate();

            Assert.AreEqual(Acre.Open, parsedInput.Acres[1, 0]);
            Assert.AreEqual(Acre.Open, parsedInput.Acres[3, 1]);
            Assert.AreEqual(Acre.Trees, parsedInput.Acres[8, 9]);
        }
    }
}
