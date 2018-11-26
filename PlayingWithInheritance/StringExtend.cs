using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingWithInheritance
{
    public static class StringExtend
    {
        public static bool ContainsNumbers(this string s)
        {
            var regEx = new System.Text.RegularExpressions.Regex(@"\d");
            return regEx.Match(s).Success;
        }

        public static bool ContainsNumbers(this string s, System.Text.RegularExpressions.Regex regEx)
        {
            return regEx.Match(s).Success;
        }
    }
}
