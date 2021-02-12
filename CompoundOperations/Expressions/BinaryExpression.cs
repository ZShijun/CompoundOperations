using PerCederberg.Grammatica.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CompoundOperations.Expressions
{
    public abstract class BinaryExpression : Expression
    {
        public BinaryExpression(ArrayList elements) : base(elements)
        {

        }

        protected override object Calculate(ArrayList elements)
        {
            return Calculate(elements[0], elements[1].ToString(), elements[2]);
        }

        protected abstract object Calculate(object left, string op, object right);
    }
}
