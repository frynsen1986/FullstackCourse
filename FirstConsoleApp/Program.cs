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
            //HelloWorld(args);

            //PlayingWithPerson();
            //PlayingWithAdd();

            //PlayingWithStructs();

            PlayingWithCollections();

        }

     

        static void HelloWorld(string[] args)
        {
            System.Console.WriteLine("Hello world");
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
            int c = Add(a, b);
            Console.WriteLine("a = {0} b = {1} c = a + b = {2}", a, b, c);

            Console.WriteLine("a = {0} b = {1}", a, b);
            int d = Add(ref a, ref b);
            Console.WriteLine("a = {0} b = {1} c = a + b = {2}", a, b, d);
        }

        static int Add(ref int x, ref int y)
        {
            x = 8;
            return x + y;
        }

        static int Add(int x, int y)
        {
            x = 8;
            return x + y;
        }


        static void PlayingWithStructs()
        {
            var coffee = new Drinks.Coffee(3,"Arabica","Baracuda");
            coffee.Strength = 4;

            Console.WriteLine(
                "Country of origin:     {0}\n" +
                "Bean:                  {1}\n" +
                "Strength:              {2}\n\n"
                , coffee.CountryOfOrigin
                , coffee.Bean
                , coffee.Strength);

            var defaultCoffee = new Drinks.Coffee();
            Console.WriteLine(
                "Country of origin:     {0}\n" +
                "Bean:                  {1}\n" +
                "Strength:              {2}"
                , defaultCoffee.CountryOfOrigin
                , defaultCoffee.Bean
                , defaultCoffee.Strength);

            defaultCoffee.Bean = "My favorite";
            defaultCoffee.CountryOfOrigin = "Fav country";
            defaultCoffee.Strength = 8;
            Console.WriteLine(
                "Country of origin:     {0}\n" +
                "Bean:                  {1}\n" +
                "Strength:              {2}"
                , defaultCoffee.CountryOfOrigin
                , defaultCoffee.Bean
                , defaultCoffee.Strength);

            var coffeeTest = new Drinks.Coffee
            {// Initializer list:
                Bean = "Ingen",
                Strength = 3,
                CountryOfOrigin = "Some place"
            };

            // Virker ikke idet structed ikke implementerer System.Collections.IEnumerable
            //var coffeeTest2 = new Drinks.Coffee
            //{// Initializer list:
            //    3,
            //    "Ingen",
            //    "Some place"
            //};

        }

        static void PlayingWithCollections()
        {
            #region Collections and Linq
            var prices = new System.Collections.Hashtable();

            prices.Add("Cafe au Lait", 1.99M);
            prices.Add("Cafe Americano", 1.89M);
            prices.Add("Cafe Mocha", 2.99M);
            prices.Add("Espresso", 1.49M);
            prices.Add("Juice", 1.11M);

            var bargins =
                from string drink in prices.Keys
                where (Decimal)prices[drink] < 1.50M
                orderby prices[drink] ascending
                select drink;

            var mostExpensive =
                from string drink in prices.Keys
                where (Decimal)prices[drink] > 1.50M
                orderby prices[drink] ascending
                select drink;

            Console.WriteLine("Printing the bargins:");
            foreach (var bargin in bargins)
            {
                Console.WriteLine(bargin + ": " + prices[bargin]);
            }


            Console.WriteLine("\nPrinting the pricy beverages:");
            foreach (string pricy in mostExpensive)
            {
                Console.WriteLine(pricy + ": " + prices[pricy]);
            }

            #endregion
        }

        


    }


}
