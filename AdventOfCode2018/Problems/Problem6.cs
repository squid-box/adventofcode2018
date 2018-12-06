namespace AdventOfCode2018.Problems
{
    using System;
    using System.Collections.Generic;

    using Utils;

    public class Problem6 : Problem
    {
        public Problem6() : base(6)
        {
        }

        public static IList<Coordinate> ParseInput(string[] input)
        {
            var coordinates = new List<Coordinate>();

            foreach (var line in input)
            {
                var tmp = line.Split(',');
                coordinates.Add(new Coordinate(Convert.ToInt32(tmp[0]), Convert.ToInt32(tmp[1])));
            }

            return coordinates;
        }

        public static int FindLargestArea(IList<Coordinate> coordinates)
        {
            return 0;
        }

        public override string Answer()
        {
            throw new NotImplementedException();
        }
    }
}
