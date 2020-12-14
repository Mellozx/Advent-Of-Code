using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day_6
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "day6Input.txt")).Split(Environment.NewLine);
            List<string> answers = FindAnswers(input);
            int sum = PartOne(answers);
            Console.WriteLine($"Part two solution: { sum }");
            sum = PartTwo(answers);
            Console.WriteLine($"Part two solution: { sum }");
        }

        private static int PartTwo(List<string> answers)
        {
            int sum = 0;
            foreach (string ans in answers) 
            {
                List<char> answersList = new List<char>();
                var temp = ans.Split(" ").Select(x => x.Distinct().ToList()).Where(x=>x.Count>0).ToList();
                for (int i = 0; i < temp.Count; i++) 
                {
                    var a = temp[i];
                    if (i == 0)
                    {
                        answersList.AddRange(a);
                    }
                    else 
                    {
                        answersList = new List<char>(answersList.Intersect(a).ToList());
                    }
                }

                sum += answersList.Count;
            }

            return sum;
        }

        private static int PartOne(List<string> answers)
        {
            int sum = 0;
            foreach (string ans in answers)
            {
                var temp = ans.Replace(" ", "").Distinct();
                var count = temp.Count();

                sum += count;
            }

            return sum;
        }

        private static List<string> FindAnswers(string[] input)
        {
            List<string> answers = new List<string>();
            string answersData = String.Empty;
            foreach (string data in input)
            {
                if (data == String.Empty)
                {
                    answersData.Trim();
                    answers.Add(answersData);
                    answersData = String.Empty;
                    continue;
                }

                answersData = answersData + " " + data;
            }

            answers.Add(answersData);
            return answers;
        }
    }
}
