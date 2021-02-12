using CompoundOperations.Calculator;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CompoundOperations.Tests.Calculator
{
    public class CompoundCalculatorTests
    {
        [Fact]
        public void CalculateTest()
        {
            Hashtable variables = new Hashtable();
            variables.Add("a", 2);

            CompoundCalculator oper = new CompoundCalculator(variables);
            object res = oper.Calculate("-5u^(1 + 2)*a + 3");
            Assert.Equal(350, res);
        }

        [Theory]
        [InlineData("1+2", 3)]
        [InlineData("1+2+3+4", 10)]
        [InlineData("1+2*3+4", 11)]
        [InlineData("(1+2)*3+4", 13)]
        [InlineData("1+2*(3+4)", 15)]
        [InlineData("1+2*(3+4)/5", 3.8)]
        [InlineData("1+2*(3+4)/5-6^2", -32.2)]
        [InlineData("1+2*(3+4)/(5-6)^2", 15)]
        [InlineData("-1+2*(3+4)/(5-6)^2", 13)]
        [InlineData("-1+2*(3+4/(6%4))^2", 49)]
        [InlineData("-(1+2)*(3+4/(6%4))^2", -75)]
        public void Calculate_ShouldBeExpectedDecimal_WhenGivenArithmeticExprWithoutVal(string exprssion, decimal expected)
        {
            CompoundCalculator oper = new CompoundCalculator();
            object res = oper.Calculate(exprssion);
            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData("1+a", 3)]
        [InlineData("1+a+b+c", 10)]
        [InlineData("1+a*b+c", 11)]
        [InlineData("(1+a)*b+c", 13)]
        [InlineData("1+a*(b+c)", 15)]
        [InlineData("1+a*(b+c)/5", 3.8)]
        [InlineData("1+a*(b+c)/5-6^2", -32.2)]
        [InlineData("1+a*(b+c)/(5-6)^2", 15)]
        [InlineData("-1+a*(b+c)/(5-6)^2", 13)]
        [InlineData("-1+a*(b+c/(6%c))^2", 49)]
        [InlineData("-(1+a)*(b+c/(6%c))^2", -75)]
        public void Calculate_ShouldBeExpectedDecimal_WhenGivenArithmeticExprWithVal(string exprssion, decimal expected)
        {
            Hashtable variables = new Hashtable();
            variables.Add("a", 2);
            variables.Add("b", 3);
            variables.Add("c", 4);
            CompoundCalculator oper = new CompoundCalculator(variables);
            object res = oper.Calculate(exprssion);
            Assert.Equal(expected, res);
        }
    }
}
