namespace _07
{
    internal static class CommandFactory
    {
        public static ICmd GetCommand(string cmd)
        {
            string[] inputs = cmd.Split(' ');

            if (inputs[0] == "$")
            {
                if (inputs[1] == "cd")
                    return new MoveCommand(inputs[2]);

                if (inputs[1] == "ls")
                    return new ListCommand();

                else
                    throw new Exception($"Invalid command: {cmd}");
            }

            else if (inputs[0] == "dir")
            {
                return new DirectoryCommand(inputs[1]);
            }

            else if (int.TryParse(inputs[0], out int size))
            {
                return new FileCommand(inputs[1], size);
            }

            else
                throw new Exception($"invalide cmd: {cmd}");
        }
    }

    internal class MoveCommand(string destination) : ICmd
    {
        public string Destination { get; set; } = destination;
    }

    internal class DirectoryCommand(string name) : ICmd
    {
        public string Name { get; set; } = name;
    }

    internal class FileCommand(string name, int size) : ICmd
    {
        public string Name { get; set; } = name;
        public int Size { get; set; } = size;
    }

    internal class ListCommand : ICmd
    {
        public List<ICmd> Commands { get; set; } = [];
    }

    internal interface ICmd
    {
    }
}
