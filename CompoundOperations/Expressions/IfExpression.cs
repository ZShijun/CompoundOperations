using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CompoundOperations.Expressions
{
    public class IfExpression : Expression
    {
        public IfExpression(ArrayList elements) : base(elements)
        {

        }

        protected override object Calculate(ArrayList elements)
        {
            bool b = Convert.ToBoolean(elements[2]);
            return b ? elements[4] : elements[6];
        }
    }
}
