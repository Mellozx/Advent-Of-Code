using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System;
using System.IO;

namespace AdventOfCode
{
    //I wanna die rn
    public class Day4 
    {
        public static void Main(string[] args)
        {
            new Day4().Solve(File.ReadAllText("day4input.txt")).ToList().ForEach(x => Console.WriteLine(x.ToString()));
        }
        public IEnumerable<object> Solve(string input)
        {
            yield return DoFirst(input);
            yield return DoSecond(input);
        }

        private int DoFirst(string input) => IsCountValid(input, cred =>
            rxs.All(kvp => cred.ContainsKey(kvp.Key))
        );

        private int DoSecond(string input) => IsCountValid(input, cred =>
            rxs.All(kvp =>
                cred.TryGetValue(kvp.Key, out var value) && Regex.IsMatch(value, "^(" + kvp.Value + ")$")
            )
        );

        Dictionary<string, string> rxs = new Dictionary<string, string>(){
            {"byr", "19[2-9][0-9]|200[0-2]"},
            {"iyr", "201[0-9]|2020"},
            {"eyr", "202[0-9]|2030"},
            {"hgt", "1[5-8][0-9]cm|19[0-3]cm|59in|6[0-9]in|7[0-6]in"},
            {"hcl", "#[0-9a-f]{6}"},
            {"ecl", "amb|blu|brn|gry|grn|hzl|oth"},
            {"pid", "[0-9]{9}"},
        };

        static int IsCountValid(string input, Func<Dictionary<string, string>, bool> isValid) =>
            input
                .Split("\n\n")
                .Select(block => block
                    .Split("\n ".ToCharArray())
                    .Select(part => part.Split(":"))
                    .ToDictionary(parts => parts[0], parts => parts[1]))
                .Count(isValid);
    }
}
