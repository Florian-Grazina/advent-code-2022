namespace _04
{
    internal class Pair
    {
        public Elf First { get; set; }
        public Elf Second { get; set; }

        public Pair(string sectionElf1, string sectionElf2)
        {
            First = new(sectionElf1);
            Second = new(sectionElf2);
        }

        public bool CheckIfFullyContains()
        {
            return First.Contains(Second) || Second.Contains(First);
        }

        public bool CheckIfOverlaps()
        {
            return First.OverLaps(Second);
        }
    }
}
