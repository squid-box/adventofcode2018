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
                new Problem1(),
				new Problem2(),
                new Problem3(),
                new Problem4()

            };

            foreach (var problem in problems)
            {
                try
                {
                    Console.WriteLine(problem);
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
