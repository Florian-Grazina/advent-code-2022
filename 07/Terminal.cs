namespace _07
{
    internal class Terminal
    {
        public DirectoryZ ActiveDirectory { get; set; }

        public Terminal()
        {
            ActiveDirectory = new DirectoryZ("/", null);
        }

        public void ExecuteCmd(ICmd cmd)
        {
            if (cmd is MoveCommand moveCmd)
                Move(moveCmd.Destination);

            else if (cmd is ListCommand listCmd)
            {
            }

            else if (cmd is DirectoryCommand dirCmd)
                AddDirectory(dirCmd);

            else if (cmd is FileCommand fileCmd)
                AddFile(fileCmd);

            else
                throw new Exception("Invalid command");
        }

        public int Print()
        {
            Move("/");
            ActiveDirectory.Print();

            var ok = ActiveDirectory.GetAllDir();
            ok = ok.OrderBy(d => d.Size).ToList();

            //return ok.Sum(d => d.Size < 100000 ? d.Size : 0);

            int system = 70000000;
            int usedSpace = ActiveDirectory.Size;

            int freeSpace = system - usedSpace;
            int requiredSpace = 30000000;

            int needToDelete = requiredSpace - freeSpace;

            foreach(DirectoryZ dir in ok)
            {
                if(needToDelete <= dir.Size)
                    return dir.Size;
            }

            return 0;
        }

        private void Move(string destination)
        {
            if (destination == "..")
                ActiveDirectory = ActiveDirectory.Parent;

            else if (destination == "/")
            {
                while (ActiveDirectory.Parent != null)
                    ActiveDirectory = ActiveDirectory.Parent;
            }

            else
            {
                DirectoryZ? newDirectory = ActiveDirectory.Directories.FirstOrDefault(d => d.Name == destination);

                if (newDirectory == null)
                    throw new Exception(destination + " not found");

                ActiveDirectory = newDirectory;
            }
        }

        private void AddFile(FileCommand fileCmd)
        {
            ActiveDirectory.Files.Add(new FileZ(fileCmd.Name, fileCmd.Size));
        }

        private void AddDirectory(DirectoryCommand dirCmd)
        {
            ActiveDirectory.Directories.Add(new DirectoryZ(dirCmd.Name, ActiveDirectory));
        }
    }
}
