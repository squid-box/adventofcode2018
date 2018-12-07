namespace AdventOfCode2018.Problems
{
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Problem7 : Problem
    {
        public Problem7() : base(7)
        {
        }

        public static SortedDictionary<char, List<char>> ParseInput(string[] input)
        {
            var dependencies = new SortedDictionary<char, List<char>>();

            foreach (var line in input)
            {
                var matches = Regex.Match(line, @"Step ([A-Z]).*step ([A-Z]) can begin\.").Groups;

                var subject = matches[2].Value[0];
                var dependsOn = matches[1].Value[0];

                if (!dependencies.ContainsKey(subject))
                {
                    dependencies.Add(subject, new List<char>());
                }

                if (!dependencies.ContainsKey(dependsOn))
                {
                    dependencies.Add(dependsOn,  new List<char>());
                }

                dependencies[subject].Add(dependsOn);
            }

            return dependencies;
        }

        public static string FindAssemblyOrder(SortedDictionary<char, List<char>> dependencies)
        {
            var order = new StringBuilder();
            var availableParts = new SortedSet<char>(dependencies.Keys);

            while (availableParts.Count > 0)
            {
                var partToRemove = '\t';

                foreach (var part in availableParts)
                {
                    if (AreDependenciesMet(dependencies[part], availableParts))
                    {
                        order.Append(part);
                        partToRemove = part;
                        break;
                    }
                }

                if (!partToRemove.Equals('\t'))
                {
                    availableParts.Remove(partToRemove);
                }
            }

            return order.ToString();
        }

        public static int DetermineAssemblyTime(SortedDictionary<char, List<char>> dependencies, int timePenalty, int workers)
        {
            return 0;
        }

        private static bool AreDependenciesMet(IEnumerable<char> dependencies, SortedSet<char> remainingParts)
        {
            foreach (var dependency in dependencies)
            {
                if (remainingParts.Contains(dependency))
                {
                    return false;
                }
            }

            return true;
        }

        public override string Answer()
        {
            var dependencies = ParseInput(Input);
            return $"Correct assembly order is \"{FindAssemblyOrder(dependencies)}\".\nWith 5 workers it would take {DetermineAssemblyTime(dependencies, 60, 5)}s.";
        }
    }
}
