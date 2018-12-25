namespace AdventOfCode2018.Problems
{
    using System;
    using System.Collections.Generic;
    using Utils;

    public class Problem18 : Problem
    {
        public Problem18() : base(18)
        {
        }

        public static LumberCollectionArea ParseInput(IList<string> input)
        {
            return new LumberCollectionArea(input);
        }

        public static int FindResourceValue(LumberCollectionArea input)
        {
            input.UpdateCounts();
            return input.Trees * input.Lumberyards;
        }

        public override string Answer()
        {
            var input = ParseInput(Input);

            for (var i = 0; i < 10; i++)
            {
                input.Iterate();
            }

            var part1 = FindResourceValue(input);

            for (var i = 0; i < 999999990; i++)
            {
                input.Iterate();
            }

            var part2 = FindResourceValue(input);

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

        public void Iterate()
        {
            var newState = new Acre[Width,Height];
            Array.Copy(Acres, 0, newState, 0, Acres.Length);

            for (var y = 0; y < Height; y++)
            {
                for (var x = 0; x < Width; x++)
                {
                    newState[x, y] = EvaluateAcre(x, y);
                }
            }

            Acres = newState;
        }

        public void UpdateCounts()
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
    }

    public enum Acre
    {
        Open,
        Trees,
        Lumberyard
    }
}
