namespace _09
{
    internal class Map
    {
        private readonly Rope head;
        private readonly Rope tail;
        private readonly MoveService moveService;
        private readonly string[,] map;
        private readonly List<PosRecord> results = [];

        public Map(int x, int y)
        {
            head = new(x, y);
            tail = new(x, y);

            moveService = new();
            map = new string[x*2, y*2];
            //FilleMap();
            AddResult();
            //UpdateMap();
            //Print();
        }

        public void Move(string input)
        {
            AddResult();

            string[] splitInput = input.Split(' ');

            string command = splitInput[0];
            int loop = int.Parse(splitInput[1]);

            for (int i = 0; i < loop; i++)
            {
                //ClearMap();
                moveService.MoveHead(command, head);
                moveService.MoveTail(tail, head);
                AddResult();
                //UpdateMap();
                //Print();
            }
            AddResult();
        }

        public int GetResults() => results.Count;

        #region private methods
        private void AddResult()
        {
            PosRecord record = new(tail.PosX, tail.PosY);

            if (!results.Contains(record))
                results.Add(record);
        }

        private void ClearMap()
        {
            map[head.PosX, head.PosY] = " . ";
            map[tail.PosX, tail.PosY] = " . ";
        }

        private void UpdateMap()
        {
            map[head.PosX, head.PosY] = " H ";
            map[tail.PosX, tail.PosY] = " T ";
        }

        private void Print()
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    Console.Write(map[x, y]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private void FilleMap()
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    map[x, y] = " . ";
                }
            }
        }
        #endregion
    }
}
