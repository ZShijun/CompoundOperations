using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CompoundOperations.Expressions
{
    public class BooleanExpression : Expression
    {
        public BooleanExpression(ArrayList elements) : base(elements)
        {

        }

        protected override object Calculate(ArrayList elements)
        {// bool操作只有取反
            bool b = Convert.ToBoolean(elements[1]);
            return !b;
        }
    }
}
