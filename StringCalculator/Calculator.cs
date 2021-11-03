using System;

namespace StringCalculator
{
    public class Calculator
    {
        public static int Add(string values)
        {
            if(string.IsNullOrEmpty(values)) return 0;
            return int.Parse((values));
        }
    }
}
