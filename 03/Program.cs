using _03;

internal class Program
{
    static void Main(string[] args)
    {
        string[] input = File.ReadAllLines("../../../input.txt");

        List<Rucksack> rucksacks = [];

        foreach(string line in input)
        {
            int length = line.Length/2;
            string item1 = line.Substring(0, length);
            string item2 = line.Substring(length);

            rucksacks.Add(new Rucksack(item1, item2));
        }

        List<ElvesGroup> groups = new List<ElvesGroup>();

        ElvesGroup tempGroup = new();

        for(int i = 0; i < rucksacks.Count; i++)
        {
            if(i % 3 == 0)
            {
                tempGroup = new();
                groups.Add(tempGroup);
            }

            tempGroup.Rucksacks.Add(rucksacks[i]);
        }

        int result = groups.Select(g => g.GetResult()).Sum();
        Console.WriteLine(result);
    }
}
