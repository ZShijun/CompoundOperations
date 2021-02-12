using System;
using System.Collections;

namespace CompoundOperations.Expressions
{
    public class ComparisonExpression : BinaryExpression
    {
        public ComparisonExpression(ArrayList elements) : base(elements)
        {
        }

        protected override object Calculate(object left, string op, object right)
        {
            decimal x = Convert.ToDecimal(left);
            decimal y = Convert.ToDecimal(right);
            return op switch
            {
                "=" => x == y,
                "<>" => x != y,
                ">" => x > y,
                "<" => x < y,
                ">=" => x >= y,
                "<=" => x <= y,
                _ => throw new Exception("unknown comparison operator: " + op),
            };
        }
    }
}
