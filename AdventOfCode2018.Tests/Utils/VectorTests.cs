namespace AdventOfCode2018.Tests.Utils
{
    using AdventOfCode2018.Utils;
    using NUnit.Framework;

    [TestFixture]
    public class VectorTests
    {
        [Test]
        public void HashCodeTest()
        {
            var one = new Vector(0, 0);
            var two = new Vector(0, 0);

            Assert.AreEqual(one.GetHashCode(), two.GetHashCode());

            one = new Vector(2, 0);

            Assert.AreNotEqual(one.GetHashCode(), two.GetHashCode());

            two = new Vector(2, 0);

            Assert.AreEqual(one.GetHashCode(), two.GetHashCode());
        }
    }
}
