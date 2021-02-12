using System;

namespace CompoundOperations.Elements.Mathematics
{
    public class ArithmeticElement : Element
    {
        public ArithmeticElement(string op, decimal x, decimal y)
        {
            Result = Calculate(op, x, y);
        }


        private decimal Calculate(string op, decimal x, decimal y)
        {
            switch (op)
            {
                case "+":
                    return x + y;
                case "-":
                    return x - y;
                case "*":
                    return x * y;
                case "/":
                    return x / y;
                case "%":
                    return x % y;
                default:
                    throw new Exception("unknown operator: " + op);
            }
        }
    }
}
