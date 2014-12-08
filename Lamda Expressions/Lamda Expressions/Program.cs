using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamda_Expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> funTimeList = new List<string>() { "blueberry", "apple", "boisenberry","pear","strawberry" };
            
            Console.WriteLine(string.Join(", ", funTimeList.OrderBy(x => x)));
            Console.WriteLine();
            Console.WriteLine(string.Join(", ", funTimeList.Where(x=>x.Contains("berry"))));
            Console.WriteLine();
            Console.WriteLine(string.Join(", ", funTimeList.Where(x => !x.Contains("berry")).OrderBy(x => x.Length)));
            Console.WriteLine();
            Console.WriteLine(string.Join(", ", funTimeList.Where(x => x.Length >= 5)));
            Console.WriteLine();
            Console.WriteLine("total number of chars: " + funTimeList.Sum(x => x.Length));
            Console.WriteLine();
            Console.WriteLine("average num of chars in list: " + funTimeList.Average(x => x.Length));
            Console.WriteLine();
            Console.WriteLine(string.Join("\n", funTimeList.Select(x => x + " has " + x.Count(y => "aeiou".Contains(y)) + " vowels")));
               
            Console.ReadKey();
        }
        
    }
}
