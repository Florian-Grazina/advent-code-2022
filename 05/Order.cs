namespace _05
{
    public class Order
    {
        public int NbOfCratesToMove { get; set; }
        public int FromIndex { get; set; }
        public int ToIndex { get; set; }

        public Order(string orderString)
        {
            string[] words = orderString.Split(' ');
            string nbOfCratesToMove = words[1];
            string fromIndex = words[3];
            string toIndex = words[5];

            int.TryParse(nbOfCratesToMove, out int nbOfCrates);
            int.TryParse(fromIndex, out int from);
            int.TryParse(toIndex, out int to);

            NbOfCratesToMove = nbOfCrates;
            FromIndex = from - 1;
            ToIndex = to - 1;
        }
    }
}
