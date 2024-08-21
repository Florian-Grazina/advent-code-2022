namespace _01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText("../../../input.txt");
            string[] data = input.Split("\r\n\r\n");
            List<Elf> Elves = [];

            foreach(string line in data)
            {
                Elves.Add(new(line));
            }

            Console.WriteLine(Elves.OrderByDescending(e => e.Calories).Take(3).Sum(c => c.Calories));
        }
    }
}
