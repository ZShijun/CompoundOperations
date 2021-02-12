using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CompoundOperations.Expressions
{
    public abstract class Expression
    {
        private readonly ArrayList _elements;

        public Expression(ArrayList elements)
        {
            this._elements = elements ?? new ArrayList();
        }
                
        public object Result
        {
            get
            {
                object result;
                if (this._elements != null
                    && this._elements.Count == 1)
                {
                    result = this._elements[0];
                }
                else
                {
                    result = Calculate(this._elements);
                }
                return result;
            }
        }

        protected abstract object Calculate(ArrayList elements);
    }
}
