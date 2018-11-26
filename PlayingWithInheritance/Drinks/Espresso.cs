using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingWithInheritance.Drinks
{
    sealed public class Espresso : Coffee
    {
        public Espresso():
            base("Royal", 200, true, "Arabica", "Brasil")
        {
        }

        public override string ToString()
        {
            string st = base.ToString();
            return string.Format("I'm an espresso:\n{0}", base.ToString());
        }
    }
}
