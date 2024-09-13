

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

            foreach(string line in input)
            {
                int x = 0;
                foreach(char c in line)
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
            for(int y = 0; y < YEdge; y++)
            {
                for(int x = 0; x < XEdge; x++)
                {
                    Console.Write(map[x, y].Height);
                }
                Console.WriteLine();
            }
        }

        public bool IsTreeVisible(Tree tree)
        {
            if(tree.X == 0 || tree.X == XEdge || tree.Y == 0 || tree.Y == YEdge)
                return true;

            else if(VisibleOnX(tree) || VisibleOnY(tree))
                return true;

            return false;
        }

        public int GetNumberOfVisibleTrees()
        {
            int result = 0;

            for (int y = 0; y < YEdge; y++)
            {
                for (int x = 0; x < XEdge; x++)
                {
                    if(IsTreeVisible(map[x, y]))
                        result++;
                }
            }

            return result;
        }

        private bool VisibleOnX(Tree tree)
        {
            bool isVisible = true;

            for(int x = tree.X; x > 0; x--)
            {
                if(map[x, tree.Y].Height >= tree.Height)
                {
                    isVisible = false;
                    break;
                }
            }

            if(isVisible)
                return isVisible;

            for (int x = tree.X; x < XEdge; x++)
            {
                if (map[x, tree.Y].Height >= tree.Height)
                {
                    isVisible = false;
                    break;
                }
            }

            return isVisible;
        }

        private bool VisibleOnY(Tree tree)
        {
            bool isVisible = true;

            for (int y = tree.Y; y > 0; y--)
            {
                if (map[tree.X, y].Height >= tree.Height)
                {
                    isVisible = false;
                    break;
                }
            }

            if (isVisible)
                return isVisible;

            for (int y = tree.Y; y < YEdge; y++)
            {
                if (map[tree.X, y].Height >= tree.Height)
                {
                    isVisible = false;
                    break;
                }
            }

            return isVisible;
        }
    }
}
