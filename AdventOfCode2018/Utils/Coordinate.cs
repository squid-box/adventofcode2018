﻿using System;

namespace AdventOfCode2018.Utils
{
    public class Coordinate
    {
        public int X { get; }
        
        public int Y { get; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"({X},{Y})";
        }

        public override bool Equals(object obj)
        {
            var other = (Coordinate) obj;
            return other.X.Equals(X) && other.Y.Equals(Y);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode();
        }

        public static int ManhattanDistance(Coordinate origin, Coordinate destination)
        {
            if (origin.Equals(destination))
            {
                return 0;
            }

            return Math.Abs((destination.X - origin.X) + (destination.Y - origin.Y));
        }
    }
}
