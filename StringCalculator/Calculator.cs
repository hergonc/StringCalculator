using System;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        public static int Add(string values)
        {
            if(string.IsNullOrEmpty(values)) return 0;
            if (values.Contains("\n")) values = values.Replace("\n", ",");
            return values.Split(',').Sum(int.Parse);
        }
    }
}
