using _05;

string input = File.ReadAllText("../../../input.txt");
string[] inputString = input.Split("\r\n\r\n");

string[] ordersString = inputString.Last().Split("\r\n");
List<Order> orders = [];

foreach (string item in ordersString)
{
    orders.Add(new(item));
}

string[] cratesString = inputString.First().Split("\r\n");
Array.Resize(ref cratesString, cratesString.Length - 1);
cratesString = cratesString.Reverse().ToArray();

StacksOfCrates? stackOfCrates = null;

foreach(string line in cratesString)
{
    string newLine = line.Replace("    ", "0").Replace("[", "").Replace("]", "").Replace(" ", "");

    if (stackOfCrates == null)
        stackOfCrates = new(newLine.Length);

    for(int i = 0; i < newLine.Length; i++)
    {
        stackOfCrates.AddCrate(i, newLine[i]);
    }
}

foreach(Order order in orders)
{
    stackOfCrates.ApplyOrder(order);
    stackOfCrates.PrintStacks();
}
Console.WriteLine();