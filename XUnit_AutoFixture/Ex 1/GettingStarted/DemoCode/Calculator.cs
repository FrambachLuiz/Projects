namespace DemoCode
{
    public class Calculator
    {
        public int Value { get; private set; }

        public void Subtract(int number)
        {
            Value -= number;
        }
    }
}
