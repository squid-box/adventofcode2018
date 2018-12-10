namespace AdventOfCode2018
{
    using System;
    using System.Collections.Generic;

    using Problems;

    public class Program
    {
        public static void Main(string[] args)
        {
            var problems = new List<Problem>
            {
                /*new Problem1(),
				new Problem2(),
                new Problem3(),
                new Problem4(),
                new Problem5(),
                new Problem6(),
                new Problem7(),
                new Problem8(),
                new Problem9(),*/
                new Problem10()

            };

            foreach (var problem in problems)
            {
                if (problem.GetType() == typeof(Problem10))
                {
                    string[] TestInput =
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

                    var lights = Problem10.ParseInput(TestInput);
                    Problem10.PrintState(lights);

                    Console.ReadLine();

                    while (true)
                    {
                        Problem10.StateAfterIterations(lights, 0);
                        Problem10.PrintState(lights);
                        Console.ReadLine();
                    }

                    continue;
                }

                try
                {
                    var startTime = DateTime.Now;
                    var answer = problem.ToString();
                    var endTime = DateTime.Now;
                    Console.WriteLine(answer);
                    Console.WriteLine($"Calculated in {(endTime-startTime).TotalMilliseconds}ms.");
                    Console.WriteLine();
                }
                catch (NotImplementedException)
                {
                }
            }

	        Console.In.ReadLine();
        }
    }
}
