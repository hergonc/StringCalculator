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
            if (string.IsNullOrEmpty(values)) return 0;
            var delimiter = GetDelimiter(ref values);
            List<int> numbers = values.Split(delimiter.ToArray(), StringSplitOptions.RemoveEmptyEntries)
                                    .Select(n => int.Parse((string) n)).ToList();
            if (numbers.Any(n => n < 0))
                throw new ArgumentException("negatives not allowed",
                    numbers.Where(n => n < 0)
                                .Select(n => $"{n}")
                                .Aggregate((exc, n) => exc + "," + n));
            return numbers.Where(n => n >= 0 && n <= 1000).Sum();
        }

        private static List<string> GetDelimiter(ref string values)
        {
            List<string> delimiter = new List<string>() {",", "\n"};
            if (values.Contains("//"))
            {
                if (values.Contains("[") && values.Contains("]"))
                {
                    Regex regex = new Regex(@"\[(.+?)\]");
                    var delimits = regex.Matches(values);
                    delimiter.AddRange(delimits.Select(delimit => delimit.Groups[1].Value));
                    values = values.Substring(values.IndexOf("\n") + 1);
                }
                else
                {
                    delimiter.Add(values.Substring(2, 1));
                    values = values.Substring(4);
                }
            }

            return delimiter;
        }
    }
}
