using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingWithInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            var cof = new Drinks.Coffee("Nescafé",95,false,"Frozen","Denmark");
            var esp = new PlayingWithInheritance.Drinks.Espresso();

            Console.WriteLine(cof);
            Console.WriteLine(esp);

            string str = "Yo M4te!";

            Console.WriteLine("Contains numbers in '{0}': {1}"
                , str, str.ContainsNumbers());

            Console.WriteLine("Contains numbers in '{0}': {1}"
                , str, str.ContainsNumbers(new System.Text.RegularExpressions.Regex(@"\d")));
        }
    }
}
