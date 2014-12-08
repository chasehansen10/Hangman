using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice_for_the_test
{
    class Program
    {
        static List<string> newList = new List<string> { "ball", "nut", "car", "paste", "edit", "no", "suck it" };
        static void Main(string[] args)
        {
            loopingLists();
            Console.ReadLine();
        }
        static void loopingLists()
        {
            Console.WriteLine(string.Join(", ", newList.OrderBy(x => x)));
            Console.WriteLine(string.Join(", ", newList.Find(x => x.Contains("aeiou"))));

        }
    }
}
