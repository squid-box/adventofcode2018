using System.Collections.Generic;

namespace AdventOfCode2018.Problems
{
    using System;

    public class Problem8 : Problem
    {
        public Problem8() : base(8)
        {
        }

	    public static Node ParseInput(string input)
	    {
		    var split = input.Split(' ');

		    for (var i = 0; i < split.Length-1; i++)
		    {
			    var numberOfChildren = Convert.ToInt32(split[i]);
			    var numberOfDataEntries = Convert.ToInt32(split[i + 1]);
		    }

		    return null;
	    }

        public override string Answer()
        {
            throw new NotImplementedException();
        }
    }

	public class Node
	{
		public List<Node> Children { get; }

		public List<int> Metadata { get; }

		public Node()
		{
			Children = new List<Node>();
			Metadata = new List<int>();
		}
	}
}
