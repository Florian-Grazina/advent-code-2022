namespace _09
{
    internal class Rope(int posX, int posY)
    {
        public int PosX { get; set; } = posX;
        public int PosY { get; set; } = posY;

        public int GetHashPos()
        {
            int hash = Tuple.Create(PosX, PosY).GetHashCode();
            return hash;
        }
    }
}
