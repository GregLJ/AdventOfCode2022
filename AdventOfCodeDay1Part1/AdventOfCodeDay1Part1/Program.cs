namespace AdventOfCodeDay1Part1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String fileName = @"C:\AdventOfCode2022\AdventOfCodeDay1Part1\AdventOfCodeDay1Part1\FoodItems.txt";

            List<List<int>> elves = new List<List<int>>();

            List<int> elfFood = new List<int>();
            
            foreach (string line in System.IO.File.ReadLines(fileName))
            {
                if (line.Trim().Length == 0)
                {
                    if (elfFood.Count > 0)
                    {
                        elves.Add(elfFood);
                        elfFood = new List<int>();
                    }
                }
                else
                {
                    int calories;
                    if (int.TryParse(line, out calories))
                    {
                        elfFood.Add(calories);
                    }
                }
            }

            if (elfFood.Count > 0)
            {
                elves.Add(elfFood);
            }

            List<int> totalCalories = new List<int>();
            for (int i = 0; i < elves.Count; i++)
            {
                List<int> elf = elves[i];
                var total = elf.Sum();
                totalCalories.Add(total);
                Console.WriteLine($"{i}: {String.Join(",", elf)}");
            }

            Console.WriteLine($"Most Calories: {totalCalories.Max()}");
            totalCalories.Sort();

            var value = 0;
            for ( int i = totalCalories.Count; i > totalCalories.Count - 3; i--)
            {
                value += totalCalories[i - 1];
            }

            Console.WriteLine($"Top Three Elves: {value}");

        }
    }
}