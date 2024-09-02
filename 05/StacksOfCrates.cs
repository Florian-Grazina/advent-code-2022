using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05
{
    public class StacksOfCrates
    {
        public List<Stack<string>> Stacks { get; set; }

        public StacksOfCrates(int stackSize)
        {
            Stacks = [];
            for (int i = 0; i < stackSize; i++)
            {
                Stacks.Add(new());
            }
        }

        public void AddCrate(int index, char item)
        {
            if(item == '0')
                return;

            Stacks[index].Push(item.ToString());
        }

        public string RemoveCreate(int index)
        {
            return Stacks[index].Pop();
        }

        public void ApplyOrder(Order order)
        {
            for(int i = 0; i < order.NbOfCratesToMove; i++)
            {
                string crate = RemoveCreate(order.FromIndex);
                Stacks[order.ToIndex].Push(crate);
            }
        }

        public void PrintStacks()
        {
            Console.WriteLine("---------------------");
            foreach (Stack<string> stack in Stacks)
            {
                stack.TryPeek(out string result);
                Console.Write(result);
            }
            Console.WriteLine("\n---------------------");
        }
    }
}
