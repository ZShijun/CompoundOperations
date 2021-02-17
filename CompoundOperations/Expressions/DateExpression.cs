using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CompoundOperations.Expressions
{
    public class DateExpression : Expression
    {
        public DateExpression(ArrayList elements) : base(elements)
        {

        }

        protected override object Calculate(ArrayList elements)
        {
            int year = Convert.ToInt32(elements[2]);
            int month = Convert.ToInt32(elements[4]);
            int day = Convert.ToInt32(elements[6]);
            return new DateTime(year, month, day);
        }
    }
}
