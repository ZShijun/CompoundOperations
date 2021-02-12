using System;
using System.Collections;
using System.IO;
using CompoundOperations.Elements.Mathematics;
using CompoundOperations.Expressions;
using CompoundOperations.Extensions;
using CompoundOperations.Grammar;
using PerCederberg.Grammatica.Runtime;

namespace CompoundOperations.Operator
{
    internal class CompoundCalculator : CompoundAnalyzer
    {
        private readonly Hashtable _variables;

        public CompoundCalculator()
        	: this(new Hashtable()) {
        }

        public CompoundCalculator(Hashtable variables) {
            this._variables = variables;
        }

        public int Operate(string expression) {
            CompoundParser parser;
            Node              node;

            parser = new CompoundParser(new StringReader(expression), this);
            parser.Prepare();
            node = parser.Parse();
            return (int) node.Values[0];
        }
        #region Token
        public override Node ExitAdd(Token node)
        {
            node.Values.Add(node.Image);
            return node;
        }

        public override Node ExitSub(Token node)
        {
            node.Values.Add(node.Image);
            return node;
        }

        public override Node ExitMul(Token node)
        {
            node.Values.Add(node.Image);
            return node;
        }

        public override Node ExitDiv(Token node)
        {
            node.Values.Add(node.Image);
            return node;
        }

        public override Node ExitMod(Token node)
        {
            node.Values.Add(node.Image);
            return node;
        }

        public override Node ExitPower(Token node)
        {
            node.Values.Add(node.Image);
            return node;
        }

        public override Node ExitInteger(Token node)
        {
            decimal val = node.Image.ParseDecIntToDecimal();
            node.Values.Add(val);
            return node;
        }

        public override Node ExitIdentifier(Token node)
        {
            node.Values.Add(_variables[node.Image]);
            return node;
        }
        #endregion

        #region Production
        public override Node ExitExpression(Production node)
        {
            node.Values.AddRange(GetChildValues(node));
            return node;
        }

        public override Node ExitLogicalExpression(Production node)
        {
            node.Values.AddRange(GetChildValues(node));
            return node;
        }

        public override Node ExitBooleanExpression(Production node)
        {
            node.Values.AddRange(GetChildValues(node));
            return node;
        }

        public override Node ExitComparisonExpression(Production node)
        {
            var values = GetChildValues(node);
            var expression = new ComparisonExpression(values);
            node.Values.Add(expression.Result);
            return node;
        }

        public override Node ExitAdditiveExpression(Production node)
        {
            var values = GetChildValues(node);
            var expression = new ArithmeticExpression(values);
            node.Values.Add(expression.Result);
            return node;
        }

        public override Node ExitMultiplicativeExpression(Production node)
        {
            var values = GetChildValues(node);
            var expression = new ArithmeticExpression(values);
            node.Values.Add(expression.Result);
            return node;
        }

        public override Node ExitNegativeExpression(Production node)
        {
            var values = GetChildValues(node);
            var expression = new NegativeExpression(values);
            node.Values.Add(expression.Result);
            return node;
        }

        public override Node ExitPowerExpression(Production node)
        {
            var values = GetChildValues(node);
            var expression = new PowerExpression(values);
            node.Values.Add(expression.Result);
            return node;
        }

        public override Node ExitAdditiveOperator(Production node)
        {
            node.Values.AddRange(GetChildValues(node));
            return node;
        }

        public override Node ExitMultiplicativeOperator(Production node)
        {
            node.Values.AddRange(GetChildValues(node));
            return node;
        }

        public override Node ExitComparisonOperator(Production node)
        {
            node.Values.AddRange(GetChildValues(node));
            return node;
        }

        public override Node ExitLogicalOperator(Production node)
        {
            node.Values.AddRange(GetChildValues(node));
            return node;
        }

        public override Node ExitFactor(Production node)
        {
            object result;

            if (node.Count == 1)
            {
                result = GetValue(GetChildAt(node, 0), 0);
            }
            else
            {
                result = GetValue(GetChildAt(node, 1), 0);
            }
            node.Values.Add(result);
            return node;
        }

        public override Node ExitAtom(Production node)
        {
            node.Values.AddRange(GetChildValues(node));
            return node;
        }
        #endregion

        private int Operate(string op, int value1, int value2)
        {
            switch (op[0])
            {
                case '+':
                    return value1 + value2;
                case '-':
                    return value1 - value2;
                case '*':
                    return value1 * value2;
                case '/':
                    return value1 / value2;
                default:
                    throw new Exception("unknown operator: " + op);
            }
        }
    }
}
