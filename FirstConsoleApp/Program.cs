using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello world");
            char input = Console.ReadKey(true).KeyChar;
            Console.WriteLine(String.Format("Du har trykket på: {0} ({1})", input, (int)input));

            Console.WriteLine(String.Format("Der er modaget {0} argumenter:",args.Length));
            for (int idx = 0; idx < args.Length; idx++)
            {
                Console.WriteLine(String.Format("Arg nummer {0} er {1}", idx, args[idx]));
            }
        }
    }
}
