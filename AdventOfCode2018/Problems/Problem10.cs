namespace AdventOfCode2018.Problems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    using Utils;

    public class Problem10 : Problem
    {
        public Problem10() : base(10)
        {
        }

        public static List<Light> ParseInput(IEnumerable<string> input)
        {
            var output = new List<Light>();

            foreach (var line in input)
            {
                output.Add(new Light(line));
            }

            return output;
        }

        public static List<Light> IncrementLights(List<Light> lights)
        {
            foreach (var light in lights)
            {
                light.IncrementPosition();
            }

            return lights;
        }

        public static List<Light> DecrementLights(List<Light> lights)
        {
            foreach (var light in lights)
            {
                light.DecrementPosition();
            }

            return lights;
        }

        public static string GenerateImage(List<Light> lights)
        {
            var previousBoundingBox = new BoundingBox(100000, 10000);
            var boundingBox = new BoundingBox(lights);

            var iterations = 0;

            // Iterate as long as bounding box shrinks.
            while (boundingBox.Size() <= previousBoundingBox.Size() || boundingBox.Height > 20)
            {
                IncrementLights(lights);
                previousBoundingBox = boundingBox;
                boundingBox = new BoundingBox(lights);
                iterations++;
            }

            // Rollback to previous iteration.
            DecrementLights(lights);

            Console.WriteLine($"Bounding box started growing after {iterations - 1} iterations.");

            // Generate image
            var sb = new StringBuilder();

            var lightCollection = new Dictionary<Coordinate, Light>();

            foreach (var light in lights)
            {
                try
                {
                    lightCollection.Add(light.Position, light);
                }
                catch (ArgumentException)
                {
                    // Don't care if two lights are in the same position (shine twice as bright?)
                }
            }

            Console.WriteLine($"Drawing image in bounding box: {boundingBox}...");

            for (var y = 0; y < boundingBox.Height; y++)
            {
                for (var x = 0; x < boundingBox.Width; x++)
                {
                    sb.Append(lightCollection.ContainsKey(new Coordinate(x - boundingBox.Origin.X - 2, y - boundingBox.Origin.Y - 2)) ? '#' : '.');
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }

        public override string Answer()
        {
            var lights = ParseInput(Input);

            var image = GenerateImage(lights);

            return image;
        }
    }

    public class Light
    {
        public Coordinate Position { get; }

        public Vector Velocity { get; }

        public Light(string input)
        {
            var matches = Regex.Match(input, @"position=<(.*),(.*)> velocity=<(.*),(.*)>").Groups;
            Position = new Coordinate(Convert.ToInt32(matches[1].Value), Convert.ToInt32(matches[2].Value));
            Velocity = new Vector(Convert.ToInt32(matches[3].Value), Convert.ToInt32(matches[4].Value));
        }

        public void IncrementPosition()
        {
            Position.AddVector(Velocity);
        }

        public void DecrementPosition()
        {
            Position.SubtractVector(Velocity);
        }

        public override string ToString()
        {
            return $"Light: Pos={Position}, Vel={Velocity}";
        }
    }

    public class BoundingBox
    {
        public int Width { get; }
        public int Height { get; }

        public Coordinate Origin { get; }

        public BoundingBox(IList<Light> lights)
        {
            var minX = lights.Min(x => x.Position.X);
            var minY = lights.Min(y => y.Position.Y);

            Width = lights.Max(x => x.Position.X) - minX;
            Height = lights.Max(y => y.Position.Y) - minY;
            Origin = new Coordinate(minX, minY);
        }

        public BoundingBox(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Size()
        {
            return Width * Height;
        }

        public override string ToString()
        {
            return $"Box: ({Width}x{Height})";
        }
    }
}
