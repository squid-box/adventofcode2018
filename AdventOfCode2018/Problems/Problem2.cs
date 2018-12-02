using System.Collections.Generic;

namespace AdventOfCode2018.Problems
{
    public class Problem2 : Problem
    {
        public Problem2() : base(2)
        {
        }

	    public static int FindChecksum(IEnumerable<string> input)
	    {
		    var twoOccurences = 0;
		    var threeOccurences = 0;

		    foreach (var id in input)
		    {
			    if (ContainsOccurrences(id, 2))
			    {
				    twoOccurences++;
			    }

			    if (ContainsOccurrences(id, 3))
			    {
				    threeOccurences++;
			    }
		    }

		    return twoOccurences * threeOccurences;
	    }

	    public static bool ContainsOccurrences(string input, int numberOfOccurences)
	    {
		    var counter = new Dictionary<char, int>();

		    foreach (var character in input)
		    {
			    if (!counter.ContainsKey(character))
			    {
					counter.Add(character, 0);
			    }

			    counter[character]++;
		    }

		    foreach (var count in counter)
		    {
			    if (count.Value == numberOfOccurences)
			    {
				    return true;
			    }
		    }

		    return false;
	    }

        public override string Answer()
        {
	        return $"ID's make the checksum: {FindChecksum(Input)}";
        }
    }
}
