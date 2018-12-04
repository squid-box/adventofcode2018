namespace AdventOfCode2018.Tests.Problems
{
    using AdventOfCode2018.Problems;

    using NUnit.Framework;

    [TestFixture]
    public class Problem4Tests
    {
        private static readonly string[] TestInput = 
        {
            "[1518-11-01 00:00] Guard #10 begins shift",
            "[1518-11-01 00:05] falls asleep",
            "[1518-11-01 00:25] wakes up",
            "[1518-11-01 00:30] falls asleep",
            "[1518-11-01 00:55] wakes up",
            "[1518-11-01 23:58] Guard #99 begins shift",
            "[1518-11-02 00:40] falls asleep",
            "[1518-11-02 00:50] wakes up",
            "[1518-11-03 00:05] Guard #10 begins shift",
            "[1518-11-03 00:24] falls asleep",
            "[1518-11-03 00:29] wakes up",
            "[1518-11-04 00:02] Guard #99 begins shift",
            "[1518-11-04 00:36] falls asleep",
            "[1518-11-04 00:46] wakes up",
            "[1518-11-05 00:03] Guard #99 begins shift",
            "[1518-11-05 00:45] falls asleep",
            "[1518-11-05 00:55] wakes up"
        };

        private static readonly string[] TestInputJumbled =
        {
            "[1518-11-03 00:29] wakes up",
            "[1518-11-04 00:02] Guard #99 begins shift",
            "[1518-11-04 00:36] falls asleep",
            "[1518-11-04 00:46] wakes up",
            "[1518-11-05 00:03] Guard #99 begins shift",
            "[1518-11-05 00:45] falls asleep",
            "[1518-11-05 00:55] wakes up",
            "[1518-11-01 00:00] Guard #10 begins shift",
            "[1518-11-01 00:55] wakes up",
            "[1518-11-01 23:58] Guard #99 begins shift",
            "[1518-11-02 00:40] falls asleep",
            "[1518-11-01 00:25] wakes up",
            "[1518-11-01 00:30] falls asleep",
            "[1518-11-01 00:05] falls asleep",
            "[1518-11-02 00:50] wakes up",
            "[1518-11-03 00:05] Guard #10 begins shift",
            "[1518-11-03 00:24] falls asleep"

        };

        [Test]
        public void TestLogSorting()
        {
            Assert.AreEqual(Problem4.ParseInput(TestInputJumbled), Problem4.ParseInput(TestInput));
        }

        [Test]
        public void Strategy1Test()
        {
            var sleepLog = Problem4.ReadLogs(TestInput);
            Assert.AreEqual(240, Problem4.Strategy1(sleepLog));
        }

        [Test]
        public void Strategy2Test()
        {
            var sleepLog = Problem4.ReadLogs(TestInput);
            Assert.AreEqual(4455, Problem4.Strategy2(sleepLog));
        }
    }
}
