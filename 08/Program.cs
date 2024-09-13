
using _08;

string[] input = File.ReadAllLines("../../../input.txt");

int height = input.Length;
int width = input[0].Length;

Map map = new (width, height);
map.Populate(input);
map.Print();

int result = map.GetNumberOfVisibleTrees();