using _09;

string[] input = File.ReadAllLines("../../../input.txt");

Map map = new(0, 0);
foreach(string line in input)
{
    map.Move(line);
}

Console.WriteLine(map.GetResults());
