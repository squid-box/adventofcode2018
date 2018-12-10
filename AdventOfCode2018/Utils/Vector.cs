namespace AdventOfCode2018.Utils
{
    public class Vector
    {
        /// <summary>
        /// 
        /// </summary>
        public int X { get; }

        /// <summary>
        /// 
        /// </summary>
        public int Y { get; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Vector(int x, int y)
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
            var other = (Vector) obj;
            return X.Equals(other.X) && Y.Equals(other.Y);
        }
    }
}
