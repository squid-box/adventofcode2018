namespace AdventOfCode2018.Problems
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;

    using Utils;

    public class Problem3 : Problem
    {
        public Problem3() : base(3)
        {
        }

        public static Dictionary<Coordinate, List<Claim>> CreateGrid(IList<Claim> input)
        {
            var grid = new ConcurrentDictionary<Coordinate, List<Claim>>();

            Parallel.ForEach(input, claim =>
            {
                for (var x = claim.Start.X; x < claim.Start.X + claim.SizeX; x++)
                {
                    for (var y = claim.Start.Y; y < claim.Start.Y + claim.SizeY; y++)
                    {
                        var coord = new Coordinate(x, y);
                        if (!grid.ContainsKey(coord))
                        {
                            grid[coord] = new List<Claim>();
                        }

                        grid[coord].Add(claim);
                    }
                }
            });

            return new Dictionary<Coordinate, List<Claim>>(grid);
        }

        public static int CountOverlappingSquares(Dictionary<Coordinate, List<Claim>> grid)
        {
            var overlappingSquares = 0;

            foreach (var square in grid)
            {
                if (square.Value.Count > 1)
                {
                    overlappingSquares++;
                }
            }

            return overlappingSquares;
        }

        public static int FindClaimWithoutOverlap(IList<Claim> input, Dictionary<Coordinate, List<Claim>> grid)
        {
            var allClaims = new HashSet<Claim>(input);
            var overlaps = new HashSet<Claim>();

            foreach (var square in grid)
            {
                if (square.Value.Count > 1)
                {
                    foreach (var overlapper in square.Value)
                    {
                        overlaps.Add(overlapper);
                    }
                }
            }

            return allClaims.Except(overlaps).ToList()[0].Id;
        }

        public override string Answer()
        {
            var input = Input.Select(line => new Claim(line)).ToList();
            var grid = CreateGrid(input);
            return $"There's {CountOverlappingSquares(grid)} overlapping squares, only claim #{FindClaimWithoutOverlap(input, grid)} doesn't overlap with other claims.";
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
