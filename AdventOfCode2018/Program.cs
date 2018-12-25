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
                new Problem9(),
                new Problem10(),*/
                new Problem18()

            };

            foreach (var problem in problems)
            {
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
