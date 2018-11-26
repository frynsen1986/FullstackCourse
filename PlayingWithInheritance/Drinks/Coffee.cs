using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingWithInheritance.Drinks
{
    public class Coffee : Beverage
    {
        public string Bean { get; set; }
        public string CountryOfOrigin { get; set; }

        public Coffee(string name, int temp, bool isFairTrade, string bean, string countryOfOrigin) :
            base(name, temp, isFairTrade)
        {
            this.Bean = bean;
            this.CountryOfOrigin = countryOfOrigin;
        }

        public override string ToString()
        {
            string st = base.ToString();
            return string.Format("{0}\nBean: {1}\nCountry of origin: {2}"
                , st, this.Bean, this.CountryOfOrigin);
        }
    }
}
