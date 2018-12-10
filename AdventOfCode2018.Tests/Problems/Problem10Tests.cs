using System;

namespace AdventOfCode2018.Tests.Problems
{
    using NUnit.Framework;

    using AdventOfCode2018.Problems;
    using AdventOfCode2018.Utils;

    [TestFixture]
    public class Problem10Tests
    {
        private static string[] TestInput =
        {
            "position=< 9,  1> velocity=< 0,  2>",
            "position=< 7,  0> velocity=<-1,  0>",
            "position=< 3, -2> velocity=<-1,  1>",
            "position=< 6, 10> velocity=<-2, -1>",
            "position=< 2, -4> velocity=< 2,  2>",
            "position=<-6, 10> velocity=< 2, -2>",
            "position=< 1,  8> velocity=< 1, -1>",
            "position=< 1,  7> velocity=< 1,  0>",
            "position=<-3, 11> velocity=< 1, -2>",
            "position=< 7,  6> velocity=<-1, -1>",
            "position=<-2,  3> velocity=< 1,  0>",
            "position=<-4,  3> velocity=< 2,  0>",
            "position=<10, -3> velocity=<-1,  1>",
            "position=< 5, 11> velocity=< 1, -2>",
            "position=< 4,  7> velocity=< 0, -1>",
            "position=< 8, -2> velocity=< 0,  1>",
            "position=<15,  0> velocity=<-2,  0>",
            "position=< 1,  6> velocity=< 1,  0>",
            "position=< 8,  9> velocity=< 0, -1>",
            "position=< 3,  3> velocity=<-1,  1>",
            "position=< 0,  5> velocity=< 0, -1>",
            "position=<-2,  2> velocity=< 2,  0>",
            "position=< 5, -2> velocity=< 1,  2>",
            "position=< 1,  4> velocity=< 2,  1>",
            "position=<-2,  7> velocity=< 2, -2>",
            "position=< 3,  6> velocity=<-1, -1>",
            "position=< 5,  0> velocity=< 1,  0>",
            "position=<-6,  0> velocity=< 2,  0>",
            "position=< 5,  9> velocity=< 1, -2>",
            "position=<14,  7> velocity=<-2,  0>",
            "position=<-3,  6> velocity=< 2, -1>"
        };

        [Test]
        public void ParseInputTest()
        {
            var parsedInput = Problem10.ParseInput(TestInput);

            var coord1 = new Coordinate(9, 1);
            Assert.IsTrue(parsedInput.ContainsKey(coord1));
            Assert.AreEqual(new Coordinate(9, 1), parsedInput[coord1].Position);
            Assert.AreEqual(new Vector(0, 2), parsedInput[coord1].Velocity);

            var coord2 = new Coordinate(10, -3);
            Assert.IsTrue(parsedInput.ContainsKey(coord2));
            Assert.AreEqual(new Coordinate(10, -3), parsedInput[coord2].Position);
            Assert.AreEqual(new Vector(-1, 1), parsedInput[coord2].Velocity);
        }

        [Test]
        public void Test()
        {
            var lights = Problem10.ParseInput(TestInput);
            Problem10.PrintState(lights);

            Console.ReadLine();

            while (true)
            {
                Problem10.StateAfterIterations(lights, 1);
                Problem10.PrintState(lights);
                Console.ReadLine();
            }
        }
    }
}
