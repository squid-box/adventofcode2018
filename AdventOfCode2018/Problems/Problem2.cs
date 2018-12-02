namespace AdventOfCode2018.Problems
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Problem2 : Problem
    {
        public Problem2() : base(2)
        {
        }

	    public static int FindChecksum(ICollection<string> input)
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

        public static string FindCommonLetters(IList<string> input)
        {
            for (var i = 0; i < input.Count-1; i++)
            {
                var current = input[i];

                for (var n = i + 1; n < input.Count; n++)
                {
                    var comparison = input[n];
                    var commonLetters = new StringBuilder();

                    var difference = 0;

                    for (var x = 0; x < current.Length; x++)
                    {
                        if (current[x].Equals(comparison[x]))
                        {
                            commonLetters.Append(current[x]);
                        }
                        else
                        {
                            difference++;
                        }
                    }

                    if (difference >= 2)
                    {
                        continue;
                    }

                    return commonLetters.ToString();
                }
            }

            return "Couldn't find it :(";
        }

        public override string Answer()
        {
	        return $"ID's make the checksum: {FindChecksum(Input)}, the common letters are: \"{FindCommonLetters(Input.ToList())}\".";
        }
    }
}
