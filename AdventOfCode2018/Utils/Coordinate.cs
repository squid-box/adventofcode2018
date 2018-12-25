namespace AdventOfCode2018.Utils
{
    using System;
    using System.Collections.Generic;

    public class Coordinate
    {
        public int X { get; private set; }
        
        public int Y { get; private set; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void AddVector(Vector vector)
        {
            X += vector.X;
            Y += vector.Y;
        }

        public void SubtractVector(Vector vector)
        {
            X -= vector.X;
            Y -= vector.Y;
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

            return Math.Abs(destination.X - origin.X) + Math.Abs(destination.Y - origin.Y);
        }

        public ICollection<Coordinate> Neighbours(int xMin, int xMax, int yMin, int yMax)
        {
            var list = new HashSet<Coordinate>();

            for (var y = Y-1; y <= Y+1; y++)
            {
                if (y < yMin || y > yMax)
                {
                    continue;
                }

                for (var x = X-1; x <= X+1; x++)
                {
                    if (x < xMin || x > xMax || x == X && y == Y)
                    {
                        continue;
                    }

                    list.Add(new Coordinate(x, y));
                }
            }

            return list;
        }
    }
}
