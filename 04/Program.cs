using _04;

string[] input = File.ReadAllLines("../../../input.txt");


List<Pair> pairs = [];

foreach (string line in input)
{
    string[] sections = line.Split(',');
    Pair pair = new(sections[0], sections[1]);
    pairs.Add(pair);
}

int result = 0;

foreach (Pair pair in pairs)
{
    if (pair.CheckIfOverlaps())
        result++;
}

Console.WriteLine(result);