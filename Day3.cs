using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day3
    {
        // i want to die 
        static void Main(string[] args)
        {
            string[] InputLoad = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "day3input.txt"));
            ulong Solvent = (ulong)DoPart1(InputLoad);
            Console.WriteLine($"solution 1 is {Solvent} trees");
            Solvent = DoPart2(InputLoad);
            Console.WriteLine($"solution 2 is {Solvent} trees");
        }

        private static int DoPart1(string[] DoInput)
        {
            return Function(DoInput, 3, 1);
        }

        private static ulong DoPart2(string[] DoInput)
        {
            List<ulong> Tree = new List<ulong>();
            List<FindSlope> Slope = new List<FindSlope>()
            {
                new FindSlope(){ X=1, Y=1},
                new FindSlope(){ X=3, Y=1},
                new FindSlope(){ X=5, Y=1},
                new FindSlope(){ X=7, Y=1},
                new FindSlope(){ X=1, Y=2}
            };

            foreach (FindSlope slopefunc in Slope)
            {
                Tree.Add((ulong)Function(DoInput, (int)slopefunc.X, (int)slopefunc.Y));
            }

            return Tree.Aggregate((ulong)1, (x, y) => x * y);

        }

        static int Function(string[] input, int xScale, int yScale)
        {
            ulong TreeCount = 0;
            int widthOfMap = input[0].Length;
            int heightOfMap = input.Length;
            int y = 0;
            int x = 0;
            while (y != heightOfMap - 1)
            {
                y += yScale;
                x += xScale;
                if (x >= widthOfMap)
                {
                    x = x - widthOfMap;
                }

                char FieldOfMap = input[y][x];
                if (FieldOfMap.ToString() == "#")
                {
                    TreeCount++;
                }
            }

            return (int)TreeCount;
        }
    }

    public class FindSlope
    {
        public ulong X { get; set; }
        public ulong Y { get; set; }
    }
}
