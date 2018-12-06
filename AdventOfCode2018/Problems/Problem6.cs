namespace AdventOfCode2018.Problems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
            // Start by finding the outer bounds of the Area of Interest

            var maxX = coordinates.Max(c => c.X) + 2;
            var maxY = coordinates.Max(c => c.Y) + 2;
            
            // Set up Area of Interest and determine owner of each point within AoI.
            var regions = new Dictionary<Coordinate, List<Coordinate>>(); // (Input Coordinate : Number of claimed points)

            var infiniteRegionPoints = new HashSet<Coordinate>();

            for (var x = 0; x <= maxX; x++)
            {
                for (var y = 0; y <= maxY; y++)
                {
                    var current = new Coordinate(x, y);

                    if (x == 0 || y == 0 || x == maxX || y == maxY)
                    {
                        // Point is in an infinite region, remember this one.
                        infiniteRegionPoints.Add(current);
                    }

                    var closest = FindClosestCoordinate(current, coordinates);

                    if (closest == null)
                    {
                        continue;
                    }

                    if (!regions.ContainsKey(closest))
                    {
                        regions.Add(closest, new List<Coordinate>());
                    }

                    regions[closest].Add(current);
                }
            }
            
            // Find and exclude infinite areas.
            var finiteRegions = new List<List<Coordinate>>();

            foreach (var region in regions)
            {
                var regionSet = new HashSet<Coordinate>(region.Value);
                if (!regionSet.Intersect(infiniteRegionPoints).Any())
                {
                    finiteRegions.Add(region.Value);
                }
            }

            return finiteRegions.Max(x => x.Count);
        }

        private static Coordinate FindClosestCoordinate(Coordinate origin, ICollection<Coordinate> potentialCoordinates)
        {
            var distances = new SortedDictionary<int, List<Coordinate>>();

            foreach (var coordinate in potentialCoordinates)
            {
                var distance = Coordinate.ManhattanDistance(origin, coordinate);

                if (!distances.ContainsKey(distance))
                {
                    distances.Add(distance, new List<Coordinate>());
                }

                distances[distance].Add(coordinate);
            }

            if (distances[distances.Keys.First()].Count > 1)
            {
                return null;
            }

            return distances[distances.Keys.First()].First();
        }

        public override string Answer()
        {
            var coordinates = ParseInput(Input);
            return $"Largest finite area is {FindLargestArea(coordinates)} units big.";
        }
    }
}