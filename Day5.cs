using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
     // kill me
    public class Day5
    {
        public static void Main(string[] args)
        {
            new Day5().Solution(File.ReadAllText("day5input.txt")).ToList().ForEach(x => Console.WriteLine(x.ToString()));
        }

        public IEnumerable<object> Solution(string input)
        {
            yield return Part1(input);
            yield return Part2(input);
        }

        int Part1(string InputFile) => Seats(InputFile).Max();

        int Part2(string input)
        {
            var SeatCount = Seats(input);
            var (min, max) = (SeatCount.Min(), SeatCount.Max());
            return Enumerable.Range(min, max - min + 1).Single(id => !SeatCount.Contains(id));
        }

        HashSet<int> Seats(string input) =>
            input
                .Replace("B", "1")
                .Replace("F", "0")
                .Replace("R", "1")
                .Replace("L", "0")
                .Split("\n")
                .Select(row => Convert.ToInt32(row, 2))
                .ToHashSet();
    }
}

