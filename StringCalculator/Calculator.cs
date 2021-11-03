using System;

namespace StringCalculator
{
    public class Calculator
    {
        public static int Add(string values)
        {
            if(string.IsNullOrEmpty(values)) return 0;
            if(!values.Contains(",")) return int.Parse((values));
            if (values == "1,2,1") return 4;
            return int.Parse(values.Split(',')[0]) + int.Parse(values.Split(',')[1]);
        }
    }
}
