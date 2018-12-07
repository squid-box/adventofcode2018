namespace AdventOfCode2018.Tests.Problems
{
    using AdventOfCode2018.Problems;

    using NUnit.Framework;

    [TestFixture]
    public class Problem7Tests
    {
        private static readonly string[] TestInput =
        {
            "Step C must be finished before step A can begin.",
            "Step C must be finished before step F can begin.",
            "Step A must be finished before step B can begin.",
            "Step A must be finished before step D can begin.",
            "Step B must be finished before step E can begin.",
            "Step D must be finished before step E can begin.",
            "Step F must be finished before step E can begin."
        };

        [Test]
        public void ParseInputTest()
        {
            var dependencies = Problem7.ParseInput(TestInput);

            Assert.AreEqual(1, dependencies['A'].Count);
            Assert.AreEqual(3, dependencies['E'].Count);

            Assert.AreEqual('C', dependencies['A'][0]);

            Assert.IsTrue(dependencies.ContainsKey('C'));

            Assert.IsTrue(dependencies['E'].Contains('B'));
            Assert.IsTrue(dependencies['E'].Contains('D'));
            Assert.IsFalse(dependencies['E'].Contains('A'));
        }

        [Test]
        public void FindAssemblyOrderTest()
        {
            var dependencies = Problem7.ParseInput(TestInput);
            Assert.AreEqual("CABDFE", Problem7.FindAssemblyOrder(dependencies));
        }

        [Test]
        public void DetermineAssemblyTimeTest()
        {
            var dependencies = Problem7.ParseInput(TestInput);
            Assert.AreEqual(15, Problem7.DetermineAssemblyTime(dependencies, 0, 2));
        }
    }
}
