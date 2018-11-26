using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingWithInheritance.Drinks
{
    abstract public class Beverage
    {
        public string Name { get; set; }

        public int ServingTemperatur { get; set; }

        public bool IsFairTrade { get; set; }

        protected Beverage(string name, int servingTemp, bool isFairTrade)
        {
            this.Name = name;
            this.ServingTemperatur = servingTemp;
            this.IsFairTrade = isFairTrade;
        }

        public override string ToString()
        {
            return string.Format("Name: {0}\nServing temperature: {1}\nIs fair trade: {2}"
                , this.Name, this.ServingTemperatur, this.IsFairTrade ? "Yes" : "No");
        }

    }
}