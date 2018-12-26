namespace AdventOfCode2018.Problems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Utils;

    public class Problem18 : Problem
    {
        public Problem18() : base(18)
        {
        }

        public override string Answer()
        {
            var input = new LumberCollectionArea(Input);

            input.Iterate(10);

            var part1 = input.ResourceValue;

            input.Iterate(1000000000);

            var part2 = input.ResourceValue;

            return $"After 10 minutes the value of resources is {part1},\nAfter 1 000 000 000 minutes the value of resources is {part2}.";
        }
    }

    public class LumberCollectionArea
    {
        public int Width { get; }

        public int Height { get; }

        public int Lumberyards { get; private set; }

        public int Trees { get; private set; }

        public Acre[,] Acres { get; private set; }

        public int ResourceValue
        {
            get
            {
                UpdateCounts();
                return Trees * Lumberyards;
            }
        }

        public LumberCollectionArea(IList<string> input)
        {
            Width = input[0].Length;
            Height = input.Count;

            Acres = new Acre[Width,Height];

            for (var y = 0; y < input.Count; y++)
            {
                for (var x = 0; x < input[y].Length; x++)
                {
                    var inputChar = input[y][x];

                    switch (inputChar)
                    {
                        case '.':
                            Acres[x, y] = Acre.Open;
                            break;
                        case '|':
                            Acres[x, y] = Acre.Trees;
                            break;
                        case '#':
                            Acres[x, y] = Acre.Lumberyard;
                            break;
                        default:
                            throw new ArgumentException($"Can't understand input \"{inputChar}\".");
                    }
                }
            }
        }

        public void Iterate(int iterations)
        {
            var previousStates = new HashSet<LumberCollectionArea>();
            var sequence = new List<LumberCollectionArea>();
            var cycle = 0;

            previousStates.Add(this);

            var foundLoop = false;

            for (var i = 0; i < iterations; i++)
            {
                var newState = new Acre[Width, Height];
                Array.Copy(Acres, 0, newState, 0, Acres.Length);

                for (var y = 0; y < Height; y++)
                {
                    for (var x = 0; x < Width; x++)
                    {
                        newState[x, y] = EvaluateAcre(x, y);
                    }
                }

                Acres = newState;

                if (previousStates.Contains(this))
                {
                    foundLoop = true;
                    cycle = previousStates.Count;
                }

                previousStates.Add(this);
                sequence.Add(this);
            }

            if (foundLoop)
            {
                var state = sequence.Last();
            }
        }

        private void UpdateCounts()
        {
            Lumberyards = 0;
            Trees = 0;

            for (var y = 0; y < Height; y++)
            {
                for (var x = 0; x < Width; x++)
                {
                    switch (Acres[x, y])
                    {
                        case Acre.Trees:
                            Trees++;
                            break;
                        case Acre.Lumberyard:
                            Lumberyards++;
                            break;
                    }
                }
            }
        }

        public Acre EvaluateAcre(int x, int y)
        {
            var target = Acres[x, y];

            var neighbouringTrees = 0;
            var neighbouringLumberyards = 0;

            foreach (var neighbour in new Coordinate(x, y).Neighbours(0, Width-1, 0, Height-1))
            {
                switch (Acres[neighbour.X, neighbour.Y])
                {
                    case Acre.Lumberyard:
                        neighbouringLumberyards++;
                        break;
                    case Acre.Trees:
                        neighbouringTrees++;
                        break;
                }
            }

            switch (target)
            {
                case Acre.Lumberyard:
                    return neighbouringTrees >= 1 && neighbouringLumberyards >= 1 ? Acre.Lumberyard : Acre.Open;
                case Acre.Open:
                    return neighbouringTrees >= 3 ? Acre.Trees : Acre.Open;
                default:
                    return neighbouringLumberyards >= 3 ? Acre.Lumberyard : Acre.Trees;
            }
        }

        public override bool Equals(object obj)
        {
            var other = (LumberCollectionArea) obj;

            if (Width != other.Width || Height != Height)
            {
                return false;
            }

            for (var y = 0; y < Height; y++)
            {
                for (var x = 0; x < Width; x++)
                {
                    if (Acres[x, y] != other.Acres[x, y])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var hash = 0;

            for (var y = 0; y < Height; y++)
            {
                for (var x = 0; x < Width; x++)
                {
                    hash += Acres[x, y].GetHashCode();
                }
            }

            return hash;
        }
    }

    public enum Acre
    {
        Open,
        Trees,
        Lumberyard
    }
}
