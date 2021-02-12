using System;
using System.Collections.Generic;
using System.Text;

namespace CompoundOperations.Elements.Mathematics
{
    public class PowerElement : Element
    {
        /// <summary>
        /// x的y次幂
        /// </summary>
        /// <param name="x">底数</param>
        /// <param name="y">指数</param>
        public PowerElement(double x, double y)
        {
            double res = Math.Pow(x, y);
            Result = Convert.ToDecimal(res);
        }
    }
}
