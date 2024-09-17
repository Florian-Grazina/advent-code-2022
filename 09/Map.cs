namespace _09
{
    internal class Map
    {
        private readonly Rope head;
        private readonly Rope tail;
        private readonly MoveService moveService;
        private readonly string[,] map;


        public Map(int x, int y)
        {
            head = new(x, y);
            tail = new(x, y);

            moveService = new();
            map = new string[6, 5];
            FilleMap();

            UpdateMap();
            Print();
        }

        public void Move(string input)
        {
            string[] splitInput = input.Split(' ');

            string command = splitInput[0];
            int loop = int.Parse(splitInput[1]);

            for (int i = 0; i < loop; i++)
            {
                ClearMap();
                moveService.MoveHead(command, head);
                moveService.MoveTail(tail, head);
                UpdateMap();
                Print();
            }
        }

        #region private methods
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
