using System;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        public static int Add(string values)
        {
            if (string.IsNullOrEmpty(values)) return 0;
            if (values.StartsWith("//"))
            {
                string delimiter = values.Substring(2, 1);
                values = values.Substring(4).Replace(delimiter, ",");
            }
            if (values.Contains("\n")) values = values.Replace("\n", ",");
            int result = values.Split(',').Where(n => int.Parse(n) >= 0 && int.Parse(n) <= 1000).Sum(int.Parse);
            if (values.Split(',').Any(n => int.Parse((string)n) < 0))
                throw new ArgumentException("negatives not allowed",
                    values.Split(',').Where(n => int.Parse(n) < 0)
                                .Select(n => $"{n}")
                                .Aggregate((exc, n) => exc + "," + n));
            return result;
        }
    }
}
