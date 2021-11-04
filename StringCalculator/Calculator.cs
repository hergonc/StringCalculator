using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        public static int Add(string values)
        {
            if (string.IsNullOrEmpty(values)) return 0;
            List<string> delimiter = new List<string>(){",", "\n"};
            if (values.StartsWith("//"))
            {
                delimiter.Add(values.Substring(2, 1));
                values = values.Substring(4);
            }
            if (values.Split(delimiter.ToArray(), StringSplitOptions.RemoveEmptyEntries).Any(n => int.Parse((string)n) < 0))
                throw new ArgumentException("negatives not allowed",
                    values.Split(delimiter.ToArray(), StringSplitOptions.RemoveEmptyEntries).Where(n => int.Parse(n) < 0)
                                .Select(n => $"{n}")
                                .Aggregate((exc, n) => exc + "," + n));
            return values.Split(delimiter.ToArray(), StringSplitOptions.RemoveEmptyEntries).Where(n => int.Parse(n) >= 0 && int.Parse(n) <= 1000).Sum(int.Parse);
        }
    }
}
