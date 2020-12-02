using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day1
    {
        static void Main(string[] args)
        {
            
            string[] input = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "day1input.txt"));
            List<int> TDF = (Array.ConvertAll(input, s => Int32.Parse(s))).ToList();
            TDF.Sort();
            int Solution
            = Reduction
            (TDF);
            Console.WriteLine($"solution is {Solution}");

            int Solution2
            = Function
            (TDF);
            Console.WriteLine($"solution 2 is {Solution2}");
        }

        static int Reduction(List<int> modelues)
        {
            foreach (int i in modelues)
            {
                foreach (int y in modelues)
                {
                    if (i + y == 2020)
                    {
                        return i * y;
                    }
                }
            }

            return 0;
        }

        static int Function(List<int> modelues)
        {
            foreach (int i in modelues)
            {
                foreach (int y in modelues)
                {
                    foreach (int j in modelues)
                    {
                        if (i + y + j == 2020)
                        {
                            return i * y * j;
                        }
                    }
                }
            }

            return 0;
        }
    }
}
