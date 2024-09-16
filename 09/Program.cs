using _09;

string[] input = File.ReadAllLines("../../../input.txt");

Map map = new(0, 4);
foreach(string line in input)
{
    map.Move(line);
}
