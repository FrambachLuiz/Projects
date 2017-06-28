using System;

namespace DemoCode
{
    public class Calculator
    {
        public int AddInts(int a, int b)
        {
            return a + b;
        }


        public double AddDoubles(double a, double b)
        {
            return a + b;
        }

        public int Divide(int value, int by)
        {
            if (value > 200)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            return value / by;
        }
    }
}