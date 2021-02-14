using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CompoundOperations.Expressions
{
    public class LogicalExpression : BinaryExpression
    {
        public LogicalExpression(ArrayList elements) : base(elements)
        {

        }

        protected override object Calculate(object left, string op, object right)
        {
            bool x = Convert.ToBoolean(left);
            bool y = Convert.ToBoolean(right);

            return op switch
            {
                "AND" => x && y,
                "OR" => x || y,
                "XOR" => x ^ y,
                _ => throw new Exception("unknown logical operator: " + op),
            };
        }
    }
}
