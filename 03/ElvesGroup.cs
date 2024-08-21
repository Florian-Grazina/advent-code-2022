using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03
{
    internal class ElvesGroup
    {
        public List<Rucksack> Rucksacks{ get; set; }

        public ElvesGroup()
        {
            Rucksacks = new List<Rucksack>();
        }

        public int GetResult()
        {
            List<string> items = Rucksacks.Select(r => r.Item1 + r.Item2).ToList();
            char[] commonItem = items.First().ToCharArray();

            for (int i = 0; i < items.Count(); i++)
            {
                commonItem = commonItem.Intersect(items[i]).ToArray();
            }

            return GetCharResult(commonItem.FirstOrDefault());
        }

        public int GetCharResult(char c)
        {
            int result = 0;
            if (char.IsUpper(c))
            {
                result = c - 'A' + 1 + 26;
            }
            else
            {
                result = c - 'a' + 1;
            }
            return result;
        }
    }
}
