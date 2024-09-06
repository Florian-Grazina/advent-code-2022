using _07;

string[] input = File.ReadAllLines("../../../input.txt");

Terminal terminal = new Terminal();

foreach (string line in input)
{
    ICmd cmd = CommandFactory.GetCommand(line);
    terminal.ExecuteCmd(cmd);
}

int result = terminal.Print();
Console.WriteLine(result);