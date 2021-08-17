using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Spinutech_20210817.Services
{
    public class NumberToWordsService
    {
        string[] a1 = new string[] { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        string[] a2 = new string[] {"", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"};
        string[] a3 = new string[] {"", "thousand", "million", "billion", "trillion", "quadrillion", "quintillion", "sextillion", "septillion", "octillion", "nonillion", "decillion", "undecillion", "duodecillion", "tredecillion", "quattuordecillion", "quindecillion", "sexdecillion", "septendecillion", "octodecillion", "novemdecillion", "vigintillion"};

        private string GetNum(string value, int j)
        {
            string s = "";
            int t = 0;
            int v = Int32.Parse(value);

            if (v > 99) s += a1[(int)(Math.Floor((double)(v / 100)))] + " hundred ";
            t = v % 100;

            if ((t > 9) && (t < 20)) s += a1[t] + " ";
            else s += a2[(int) (Math.Floor((double)(t / 10)))] + " " + a1[t % 10] + " ";

            if (v != 0) s += a3[j] + " ";
            return s;
        }

        public string Evaluate(string value)
        {
            try
            {
                Regex rgx = new Regex(@"^[0-9]*(\.[0-9]{2}){1}?$");
                if (!rgx.IsMatch(value)) return "Number is in the incorrect format. Please try again.";

                string decimalPart = value.Substring(value.Length - 2, 2);
                value = value.Substring(0, value.Length - 3);

                string[] a = null;
                string result = "";
                decimal numValue = Convert.ToDecimal(value);

                if (numValue == 0)
                {
                    result += "Zero";
                }
                else
                {
                    for (var i = value.Length - 3; i > 0; i -= 3) value = value.Substring(0, i) + "," + value.Substring(i);
                    a = value.Split(',');
                    for (var i = 0; i <= a.Length - 1; i++) result += GetNum(a[i], Math.Abs((a.Length - 1) - i));
                }
                result = result.Trim();
                if (result.Length > 0) result = result.Substring(0, 1).ToUpper() + result.Substring(1) + " and " + decimalPart + "/100 dollars.";

                return result;
            }
            catch(Exception e)
            {
                return "An error occurred, please try again.";
            }
        }

    }
}