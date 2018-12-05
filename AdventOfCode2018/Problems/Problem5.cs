namespace AdventOfCode2018.Problems
{
    using System.Collections.Concurrent;
    using System.Linq;
    using System.Threading.Tasks;

    public class Problem5 : Problem
    {
        public Problem5() : base(5)
        {
        }

        public static int PerformReaction(string polymer)
        {
            var units = polymer.ToList();
            var listChanged = true;

            while (units.Count > 0 && listChanged)
            {
                listChanged = false;

                for (var i = 0; i < units.Count - 1; i++)
                {
                    var current = units[i];
                    var next = units[i + 1];

                    if (char.ToUpper(current).Equals(char.ToUpper(next)) && !current.Equals(next))
                    {
                        units.RemoveAt(i);
                        units.RemoveAt(i); // List changes, so i+1 is now i.
                        i++;
                        listChanged = true;
                    }
                }
            }

            return units.Count;
        }

        public static int FindBestReduction(string input)
        {
            var lengths = new ConcurrentBag<int>();

            Parallel.For(97, 123, ascii =>
            {
                var targetChar = (char)ascii;
                var newInput = input.Replace(targetChar.ToString(), "").Replace(char.ToUpper(targetChar).ToString(), "");

                lengths.Add(PerformReaction(newInput));
            });

            return lengths.Min();
        }

        public override string Answer()
        {
            return $"After reactions are done {PerformReaction(Input[0])} units remain.\nMost efficient reduction leaves {FindBestReduction(Input[0])} units.";
        }
    }
}
