using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class Calculator
    {
        public static int Add(string values)
        {
            var delimiters = GetDelimiter(ref values);
            List<int> numbers = values.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(n => int.Parse((string)n)).ToList();
            if (numbers.Any(n => n < 0))
                throw new ArgumentException("negatives not allowed",
                    numbers.Where(n => n < 0)
                                .Select(n => $"{n}")
                                .Aggregate((exc, n) => exc + "," + n));
            return numbers.Where(n => n >= 0 && n <= 1000).Sum();
        }

        private static string[] GetDelimiter(ref string values)
        {
            List<string> delimiter = new List<string>() { ",", "\n" };
            string patron = Regex.IsMatch(values, @"\[(.+?)\]") ? @"\[(.+?)\]" : "//(.+?)\n";
            if (Regex.IsMatch(values, patron))
            {
                delimiter.AddRange(new Regex(patron).Matches(values).Select(delimit => delimit.Groups[1].Value));
                values = values.Substring(values.IndexOf("\n") + 1);
            }
            return delimiter.ToArray();
        }
    }
}
