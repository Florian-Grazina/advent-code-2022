

namespace _08
{
    internal class Map(int width, int height)
    {
        private readonly Tree[,] map = new Tree[width, height];

        private int YEdge => map.GetLength(1);
        private int XEdge => map.GetLength(0);


        public int this[int x, int y]
        {
            get => map[x, y].Height;
            set => map[x, y].Height = value;
        }

        public void Populate(IEnumerable<string> input)
        {
            int y = 0;

            foreach (string line in input)
            {
                int x = 0;
                foreach (char c in line)
                {
                    int height = int.Parse(c.ToString());
                    map[x, y] = new Tree(height, x, y);
                    x++;
                }
                y++;
            }
        }

        public void Print()
        {
            for (int y = 0; y < YEdge; y++)
            {
                for (int x = 0; x < XEdge; x++)
                {
                    Console.Write(map[x, y].Height);
                }
                Console.WriteLine();
            }
        }

        public int GetScore(Tree tree)
        {
            if (tree.X == 0 || tree.X == XEdge - 1 || tree.Y == 0 || tree.Y == YEdge - 1)
                return 0;

            int topTrees = VisibleTreesTop(tree);
            int botTrees = VisibleTreesBot(tree);
            int rightTrees = VisibleTreesRight(tree);
            int leftTrees = VisibleTreesLeft(tree);

            return topTrees * botTrees * rightTrees * leftTrees;
        }

        public int GetNumberOfVisibleTrees()
        {
            int result = 0;

            for (int y = 0; y < YEdge; y++)
            {
                for (int x = 0; x < XEdge; x++)
                {
                    int score = GetScore(map[x, y]);
                    if (score > result)
                        result = score;
                }
            }

            return result;
        }

        private int VisibleTreesTop(Tree tree) => NbOfVisibleTrees(tree, -1, 0);
        private int VisibleTreesBot(Tree tree) => NbOfVisibleTrees(tree, 1, 0);
        private int VisibleTreesRight(Tree tree) => NbOfVisibleTrees(tree, 0, 1);
        private int VisibleTreesLeft(Tree tree) => NbOfVisibleTrees(tree, 0, -1);


        private int NbOfVisibleTrees(Tree tree, int deltaX, int deltaY)
        {
            int startX = tree.X + deltaX;
            int startY = tree.Y + deltaY;
            int result = 0;

            while (startX >= 0 && startX < XEdge && startY >= 0 && startY < YEdge)
            {
                result ++;

                if (map[startX, startY].Height >= tree.Height)
                    break;

                startX += deltaX;
                startY += deltaY;
            }

            return result;
        }
    }
}
