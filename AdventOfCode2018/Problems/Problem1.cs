namespace AdventOfCode2018.Problems
{
	using System;
	using System.Collections.Generic;

	public class Problem1 : Problem
    {
        public Problem1() : base(1)
        {
        }

	    public static int FindResultingFrequency(IEnumerable<string> input)
	    {
		    var sum = 0;

			foreach(var i in input)
			{
				sum += Convert.ToInt32(i);
			}

		    return sum;
	    }

	    public static int FindFirstRepeatingFrequency(IEnumerable<string> input)
	    {
		    var sum = 0;
		    var set = new HashSet<int> {0};

		    while (true)
		    {
			    foreach (var i in input)
			    {
				    sum += Convert.ToInt32(i);

				    if (!set.Add(sum))
				    {
					    return sum;
				    }
			    }
		    }
	    }

        public override string Answer()
        {
			var part1 = FindResultingFrequency(Input);
	        var part2 = FindFirstRepeatingFrequency(Input);

	        return $"Resulting frequency is {part1}, first repeated frequency is {part2}.";
        }
    }
}
