using AdventOfCode2018.Utils;

namespace AdventOfCode2018.Problems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Problem3 : Problem
    {
        public Problem3() : base(3)
        {
        }

        public static int CountOverlappingSquares(IEnumerable<Claim> input)
        {


            return 0;
        }

        public override string Answer()
        {
            var input = Input.Select(line => new Claim(line));

            return $"There's {CountOverlappingSquares(input)} overlapping squares.";
        }
    }

    public struct Claim
    {
        public int Id { get; }

        public Coordinate Start { get; }

        public int SizeX { get; }

        public int SizeY { get; }

        public Claim(string input)
        {
            var split1 = input.Split('@');
            Id = Convert.ToInt32(split1[0].Substring(1).Trim());

            var split2 = split1[1].Split(':');
            var start = split2[0].Split(',');
            var size = split2[1].Split('x');

            Start = new Coordinate(Convert.ToInt32(start[0]), Convert.ToInt32(start[1]));

            SizeX = Convert.ToInt32(size[0]);
            SizeY = Convert.ToInt32(size[1]);
        }
    }
}
