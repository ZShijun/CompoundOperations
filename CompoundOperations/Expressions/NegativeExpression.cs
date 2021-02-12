using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CompoundOperations.Expressions
{
    public class NegativeExpression : Expression
    {
        public NegativeExpression(ArrayList elements) : base(elements)
        {

        }

        protected override object Calculate(ArrayList elements)
        {
            if (elements.Count == 2)
            {
                elements.Insert(0, 0);
            }

            var arithmetic = new ArithmeticExpression(elements);
            return arithmetic.Result;
        }
    }
}
