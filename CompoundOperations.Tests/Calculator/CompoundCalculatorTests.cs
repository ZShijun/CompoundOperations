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
            CompoundCalculator oper = new CompoundCalculator();
            object res = oper.Calculate("0x12");
            Assert.Equal(true, res);
        }

        #region 数值运算
        [Theory]
        [InlineData("1u+2", 3)]
        [InlineData("1+2ul+3+4L", 10)]
        [InlineData("1+2*3+4lU", 11)]
        [InlineData("(1+2)*3+4l", 13)]
        [InlineData("1+2*(3+4U)", 15)]
        [InlineData("1+2*(3+4lu)/5", 3.8)]
        [InlineData("1+2*(3+4LU)/5-6^2", -32.2)]
        [InlineData("1+2*(3+4UL)/(5-6)^2", 15)]
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
        #endregion

        #region 比较运算
        [Theory]
        [InlineData("1=2", false)]
        [InlineData("1<>2", true)]
        [InlineData("1>2", false)]
        [InlineData("1>=2", false)]
        [InlineData("1<2", true)]
        [InlineData("1<=2", true)]
        public void Calculate_ShouldBeExpectedBoolean_WhenGivenCompareExprWithoutVal(string exprssion, bool expected)
        {
            CompoundCalculator oper = new CompoundCalculator();
            object res = oper.Calculate(exprssion);
            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData("a=b", false)]
        [InlineData("a<>b", true)]
        [InlineData("a>b", false)]
        [InlineData("a>=b", false)]
        [InlineData("a<b", true)]
        [InlineData("a<=b", true)]
        public void Calculate_ShouldBeExpectedBoolean_WhenGivenCompareExprWithVal(string exprssion, bool expected)
        {
            Hashtable variables = new Hashtable();
            variables.Add("a", 1);
            variables.Add("b", 2);
            CompoundCalculator oper = new CompoundCalculator(variables);
            object res = oper.Calculate(exprssion);
            Assert.Equal(expected, res);
        }
        #endregion

        #region 逻辑运算
        [Theory]
        [InlineData("not true", false)]
        [InlineData("not false", true)]
        [InlineData("not 1>=2", true)]
        [InlineData("1>=2 and 3<4", false)]
        [InlineData("1>=2 OR 3<4", true)]
        [InlineData("1>=2 XOR 3<4", true)]
        [InlineData("1<=2 XOR 3<4", false)]
        [InlineData("1>=2 XOR 3<4 and not 5<6 or 6=7 and not true", false)]
        public void Calculate_ShouldBeExpectedBoolean_WhenGivenLogicalExprWithoutVal(string exprssion, bool expected)
        {
            CompoundCalculator oper = new CompoundCalculator();
            object res = oper.Calculate(exprssion);
            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData("not a", false)]
        [InlineData("not false", true)]
        [InlineData("not 1>=b", true)]
        [InlineData("1>=b and 3<4", false)]
        [InlineData("1>=b OR 3<4", true)]
        [InlineData("1>=b XOR 3<4", true)]
        [InlineData("1<=b XOR 3<4", false)]
        [InlineData("1>=b XOR 3<4 and not 5<6 or 6=7 and not a", false)]
        public void Calculate_ShouldBeExpectedBoolean_WhenGivenLogicalExprWithVal(string exprssion, bool expected)
        {
            Hashtable variables = new Hashtable();
            variables.Add("a", true);
            variables.Add("b", 2);
            CompoundCalculator oper = new CompoundCalculator(variables);
            object res = oper.Calculate(exprssion);
            Assert.Equal(expected, res);
        }
        #endregion
    }
}
