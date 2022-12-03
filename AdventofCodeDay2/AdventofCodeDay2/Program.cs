using System.Collections.Specialized;
using System.Runtime.InteropServices;

namespace AdventofCodeDay2
{
    public class Program
    {
        static void Main(string[] args)
        {
            string strategyGuide = @"C:\AdventOfCode2022\AdventofCodeDay2\AdventofCodeDay2\StrategyGuide.txt";

            Part1(strategyGuide);



        }
        static void Part1(string strategyGuide)
        {
            var outcomeFinder = new OutcomeFinder();
            var game = new List<Round>();


            foreach (var item in File.ReadAllLines(strategyGuide))
            {
                
                var round = new Round(outcomeFinder);
                var splitItems = item.Split(' ');

                round.MapToOutcome(splitItems[0], splitItems[1]);

                game.Add(round);
            }

            Console.WriteLine("Your total score: {0}", game.Sum(r => r.GetOutcome()));
        }
    }
}