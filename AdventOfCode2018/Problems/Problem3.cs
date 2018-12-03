namespace AdventOfCode2018.Problems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Utils;

    public class Problem3 : Problem
    {
        public Problem3() : base(3)
        {
        }

        public static int CountOverlappingSquares(IEnumerable<Claim> input)
        {
            var grid = new Dictionary<int, Dictionary<int, HashSet<Claim>>>();

            foreach (var claim in input)
            {
                for (var x = claim.Start.X; x < claim.Start.X + claim.SizeX; x++)
                {
                    if (!grid.ContainsKey(x))
                    {
                        grid[x] = new Dictionary<int, HashSet<Claim>>();
                    }

                    for (var y = claim.Start.Y; y < claim.Start.Y + claim.SizeY; y++)
                    {
                        if (!grid[x].ContainsKey(y))
                        {
                            grid[x][y] = new HashSet<Claim>();
                        }

                        grid[x][y].Add(claim);
                    }
                }
            }

            var overlappingSquares = 0;

            foreach (var x in grid.Keys)
            {
                foreach (var y in grid[x].Keys)
                {
                    if (grid[x][y].Count > 1)
                    {
                        overlappingSquares++;
                    }
                }
            }

            return overlappingSquares;
        }

        public static int FindClaimWithoutOverlap(IEnumerable<Claim> input)
        {
            var grid = new Dictionary<int, Dictionary<int, HashSet<Claim>>>();

            foreach (var claim in input)
            {
                for (var x = claim.Start.X; x < claim.Start.X + claim.SizeX; x++)
                {
                    if (!grid.ContainsKey(x))
                    {
                        grid[x] = new Dictionary<int, HashSet<Claim>>();
                    }

                    for (var y = claim.Start.Y; y < claim.Start.Y + claim.SizeY; y++)
                    {
                        if (!grid[x].ContainsKey(y))
                        {
                            grid[x][y] = new HashSet<Claim>();
                        }

                        grid[x][y].Add(claim);
                    }
                }
            }

            var noOverlaps = new HashSet<int>();

            foreach (var claim in input)
            {
                noOverlaps.Add(claim.Id);
            }

            foreach (var x in grid.Keys)
            {
                foreach (var y in grid[x].Keys)
                {
                    if (grid[x][y].Count > 1)
                    {
                        foreach (var overlapper in grid[x][y])
                        {
                            noOverlaps.Remove(overlapper.Id);
                        }
                    }
                }
            }

            return noOverlaps.ToList()[0];
        }

        public override string Answer()
        {
            var input = Input.Select(line => new Claim(line));
            return $"There's {CountOverlappingSquares(input)} overlapping squares, only claim #{FindClaimWithoutOverlap(input)} doesn't overlap with other claims.";
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

        public override string ToString()
        {
            return $"ID{Id}: @{Start} : {SizeX}x{SizeY}";
        }
    }
}
