using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode2018.Utils;

namespace AdventOfCode2018.Problems
{
    using System;

    public class Problem10 : Problem
    {
        public Problem10() : base(10)
        {
        }

        public static Dictionary<Coordinate, Light> ParseInput(IEnumerable<string> input)
        {
            var output = new Dictionary<Coordinate, Light>();

            foreach (var line in input)
            {
                var light = new Light(line);
                output.Add(light.Position, light);
            }

            return output;
        }

        public static Dictionary<Coordinate, Light> StateAfterIterations(Dictionary<Coordinate, Light> lights, int iterations)
        {
            for (var i = 0; i <= iterations; i++)
            {
                foreach (var light in lights)
                {
                    light.Value.IncrementPosition();
                }
            }

            return lights;
        }

        public static void PrintState(Dictionary<Coordinate, Light> lights)
        {
            var xCorrection = -lights.Keys.Min(x => x.X);
            var yCorrection = -lights.Keys.Min(y => y.Y);

            var maxX = lights.Keys.Max(x => x.X);
            var maxY = lights.Keys.Max(y => y.Y);

            Console.WriteLine($"Correction: X={xCorrection} , Y={yCorrection}");
            Console.WriteLine($"Max: X={maxX} , Y={maxY}");

            var numberOfLightsPrinted = 0;

            for (var y = 0; y < maxY + yCorrection; y++)
            {
                for (var x = 0; x < maxX + xCorrection; x++)
                {
                    if (lights.ContainsKey(new Coordinate(x - xCorrection, y - yCorrection)))
                    {
                        Console.Write("#");
                        numberOfLightsPrinted++;
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine($"Printed {numberOfLightsPrinted}/{lights.Count} lights.");
        }

        public override string Answer()
        {
            return "";
        }
    }

    public struct Light
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
    }

    
}
