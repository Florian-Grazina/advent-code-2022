namespace _04
{
    internal class Elf
    {
        public int SectionStart { get; set; }
        public int SectionEnd { get; set; }

        public Elf(string section)
        {
            string[] parts = section.Split('-');
            SectionStart = int.Parse(parts[0]);
            SectionEnd = int.Parse(parts[1]);
        }

        public bool Contains(Elf other)
        {
            return SectionStart <= other.SectionStart && SectionEnd >= other.SectionEnd;
        }

        public bool OverLaps(Elf other)
        {
           return SectionStart >= other.SectionStart && SectionStart <= other.SectionEnd
                || SectionEnd >= other.SectionStart && SectionEnd <= other.SectionEnd
                || SectionStart <= other.SectionStart && SectionEnd >= other.SectionEnd
                || SectionStart >= other.SectionStart && SectionEnd <= other.SectionEnd;
        }
    }
}
