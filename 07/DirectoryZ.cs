namespace _07
{
    internal class DirectoryZ
    {
        public string Name { get; set; }
        public DirectoryZ Parent { get; set; }
        public List<FileZ> Files { get; set; }
        public List<DirectoryZ> Directories { get; set; }

        public int Size => GetSize();

        public DirectoryZ(string name, DirectoryZ parent)
        {
            Name = name;
            Parent = parent;
            Files = [];
            Directories = [];
        }

        public void Print()
        {
            Directories.ForEach(d => d.Print());

            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Size: {Size}");
            Console.WriteLine();
        }

        public List<DirectoryZ> GetAllDir()
        {
            List<DirectoryZ> allDirectories = new List<DirectoryZ>();

            Directories.ForEach(d =>
            {
                allDirectories.Add(d);
                allDirectories.AddRange(d.GetAllDir());
            });

            return allDirectories;
        }

        private int GetSize()
        {
            int filesSize = Files.Sum(f => f.Size);
            int directoriesSize = Directories.Sum(d => d.Size);

            return filesSize + directoriesSize;
        }
    }
}
