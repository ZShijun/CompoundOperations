using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CompoundOperations.Expressions
{
    public class PowerExpression : BinaryExpression
    {
        public PowerExpression(ArrayList elements) : base(elements)
        {

        }

        protected override object Calculate(object left, string op, object right)
        {
            double x = Convert.ToDouble(left);
            double y = Convert.ToDouble(right);
            double res = Math.Pow(x, y);
            return Convert.ToDecimal(res);
        }
    }
}
