using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01
{
    internal class Elf
    {
        public int Calories { get; set; }


        public Elf(string data)
        {
            Parse(data);
        }

        private void Parse(string data)
        {
            foreach (var item in data.Split("\r\n"))
            {
                Calories += int.Parse(item);
            }
        }
    }
}
