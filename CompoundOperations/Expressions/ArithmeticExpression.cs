using System;
using System.Collections;

namespace CompoundOperations.Expressions
{
    public class ArithmeticExpression : BinaryExpression
    {
        public ArithmeticExpression(ArrayList elements) : base(elements)
        {

        }

        protected override object Calculate(object left, string op, object right)
        {
            if (left.GetType() == typeof(string)
                && op == "+")
            {
                return left.ToString() + right.ToString();
            }

            decimal x = Convert.ToDecimal(left);
            decimal y = Convert.ToDecimal(right);
            return op switch
            {
                "+" => x + y,
                "-" => x - y,
                "*" => x * y,
                "/" => x / y,
                "%" => x % y,
                _ => throw new Exception("unknown arithmetic operator: " + op),
            };
        }
    }
}
