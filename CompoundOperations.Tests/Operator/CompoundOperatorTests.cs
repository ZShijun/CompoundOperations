using CompoundOperations.Operator;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CompoundOperations.Tests.Operator
{
    public class CompoundOperatorTests
    {
        [Fact]
        public void CalculateTest()
        {
            Hashtable variables = new Hashtable();
            variables.Add("a", 2);

            CompoundCalculator oper = new CompoundCalculator(variables);
            int res = oper.Operate("-5u^(1 + 2)*a + 3");
            Assert.Equal(350, res);
        }
    }
}
