namespace AdventOfCode2018.Problems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Problem8 : Problem
    {
        public Problem8() : base(8)
        {
        }
	    public static Node ParseInput(string input)
	    {
		    var split = input.Split(' ').Select(i => Convert.ToInt32(i)).ToList();
	        var index = 0;

	        return ParseNode(split, ref index);
	    }

        private static Node ParseNode(IList<int> numbers, ref int index)
        {
            var node = new Node();
            var children = numbers[index++];
            var metadata = numbers[index++];

            for (var child = 0; child < children; child++)
            {
                node.Children.Add(ParseNode(numbers, ref index));
            }

            for (var data = 0; data < metadata; data++)
            {
                node.Metadata.Add(numbers[index++]);
            }

            return node;
        }

        public static int FindMetadataSum(Node node)
        {
            var sum = node.Metadata.Sum();

            foreach (var child in node.Children)
            {
                sum += FindMetadataSum(child);
            }

            return sum;
        }

        public static int FindValue(Node node)
        {
            if (node.Children.Count == 0)
            {
                return node.Metadata.Sum();
            }

            var value = 0;

            foreach (var data in node.Metadata)
            {
                if (data <= node.Children.Count)
                {
                    value += FindValue(node.Children[data-1]);
                }
            }

            return value;
        }

        public override string Answer()
        {
            var rootNode = ParseInput(Input[0]);
            return $"The sum of all metadata entries is {FindMetadataSum(rootNode)}, the value of the root node is {FindValue(rootNode)}.";
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
