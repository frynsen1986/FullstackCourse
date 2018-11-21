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
            HelloWorld(args);

            PlayingWithPerson();
            PlayingWithAdd();

            

        }

     

        static void HelloWorld(string[] args)
        {
            Console.WriteLine("Hello world");
            char input = Console.ReadKey(true).KeyChar;
            Console.WriteLine("Du har trykket på: {0} ({1})", input, (int)input);

            Console.WriteLine("Der er modaget {0} argumenter:", args.Length);
            for (int idx = 0; idx < args.Length; idx++)
            {
                Console.WriteLine("Arg nummer {0} er {1}", idx, args[idx]);
            }
        }

        static void PlayingWithPerson()
        {
            var minPerson = new FirstConsoleApp.Persons.Person();

            Console.WriteLine("Alder på person: " + minPerson.Age);
        }
        
        static void PlayingWithAdd()
        {
            int a = 4, b = 2;
            Console.WriteLine("a = {0} b = {1}", a, b);
            int c = Add(ref a, ref b);
            Console.WriteLine("a = {0} b = {1} c = a + b = {2}", a, b, c);
        }

        static int Add(ref int x, ref int y)
        {
            x = 8;
            return x + y;
        }
    }


}
