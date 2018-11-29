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
                new Problem1()

            };

            foreach (var problem in problems)
            {
                Console.WriteLine(problem);
            }
        }
    }
}
