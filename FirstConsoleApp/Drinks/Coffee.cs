using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.Drinks
{
    public struct Coffee
    {
        private int strength;
        public int Strength
        {
            get { return strength; }
            set {
                if (strength <= 0)
                    strength = value;
            }
        }
        private string bean;
        public string Bean
        {
            get => bean;    // Lambda for at returnere bean.
            set
            {
                if (string.IsNullOrEmpty(bean))
                    bean = value;
            }

        }
        private string countryOfOrigin;
        public string CountryOfOrigin
        {
            get => countryOfOrigin;    // Lambda for at returnere bean.
            set
            {
                if (string.IsNullOrEmpty(countryOfOrigin))
                    countryOfOrigin = value;
            }

        }

        public Coffee(int strength, string bean, string countryOfOrigin)
        {
            this.strength = strength;
            this.bean = bean;
            this.countryOfOrigin = countryOfOrigin;
        }
    }
}
