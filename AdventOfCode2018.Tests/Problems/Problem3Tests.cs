using System.Linq;

namespace AdventOfCode2018.Tests.Problems
{
    using AdventOfCode2018.Problems;

    using NUnit.Framework;

    [TestFixture]
    public class Problem3Tests
    {
        private static readonly string[] TestInput =
        {
            "#1 @ 1,3: 4x4",
            "#2 @ 3,1: 4x4",
            "#3 @ 5,5: 2x2"
        };

        [Test]
        public void InputParsingTest()
        {
            var claim1 = new Claim(TestInput[0]);
            var claim2 = new Claim(TestInput[1]);
            var claim3 = new Claim(TestInput[2]);

            Assert.AreEqual(1, claim1.Id);
            Assert.AreEqual(4, claim1.SizeX);
            Assert.AreEqual(4, claim1.SizeY);
            Assert.AreEqual(1, claim1.Start.X);
            Assert.AreEqual(3, claim1.Start.Y);

            Assert.AreEqual(2, claim2.Id);
            Assert.AreEqual(4, claim2.SizeX);
            Assert.AreEqual(4, claim2.SizeY);
            Assert.AreEqual(3, claim2.Start.X);
            Assert.AreEqual(1, claim2.Start.Y);

            Assert.AreEqual(3, claim3.Id);
            Assert.AreEqual(2, claim3.SizeX);
            Assert.AreEqual(2, claim3.SizeY);
            Assert.AreEqual(5, claim3.Start.X);
            Assert.AreEqual(5, claim3.Start.Y);
        }

        [Test]
        public void CountOverlappingSquaresTest()
        {
            var claims = TestInput.Select(x => new Claim(x));
            Assert.AreEqual(4, Problem3.CountOverlappingSquares(claims));
        }
    }
}
