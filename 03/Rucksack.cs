
namespace _03
{
    internal class Rucksack
    {
        public Rucksack(string item1, string item2)
        {
            Item1 = item1;
            Item2 = item2;
        }

        public string Item1 { get; set; }
        public string Item2 { get; set; }

        public int GetResult()
        {
            char c = Item1.Intersect(Item2).FirstOrDefault();
            int result = 0;
            if(char.IsUpper(c))
            {
                result = c - 'A' + 1 + 26;
            }
            else{
                result = c - 'a' + 1;
            }
            return result;
        }
    }
}
