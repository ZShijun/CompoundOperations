using System;
using System.Collections;
using System.IO;
using CompoundOperations.Expressions;
using CompoundOperations.Extensions;
using CompoundOperations.Grammar;
using PerCederberg.Grammatica.Runtime;

namespace CompoundOperations.Calculator
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

        public object Calculate(string expression)
        {
            CompoundParser parser = new CompoundParser(new StringReader(expression), this);
            parser.Prepare();
            Node node = parser.Parse();
            return node.Values[0];
        }

        public T Calculate<T>(string expression)
        {
            CompoundParser parser = new CompoundParser(new StringReader(expression), this);
            parser.Prepare();
            Node node = parser.Parse();
            return (T)node.Values[0];
        }

        #region Token
        #region + Arithmetics
        public override Node ExitAdd(Token node)
        {
            node.Values.Add("+");
            return node;
        }

        public override Node ExitSub(Token node)
        {
            node.Values.Add("-");
            return node;
        }

        public override Node ExitMul(Token node)
        {
            node.Values.Add("*");
            return node;
        }

        public override Node ExitDiv(Token node)
        {
            node.Values.Add("/");
            return node;
        }

        public override Node ExitMod(Token node)
        {
            node.Values.Add("%");
            return node;
        }

        public override Node ExitPower(Token node)
        {
            node.Values.Add("^");
            return node;
        } 
        #endregion

        #region + Logicals
        public override Node ExitAnd(Token node)
        {
            node.Values.Add("AND");
            return node;
        }
        public override Node ExitOr(Token node)
        {
            node.Values.Add("OR");
            return node;
        }

        public override Node ExitXor(Token node)
        {
            node.Values.Add("XOR");
            return node;
        }

        #endregion

        #region + Booleans
        public override Node ExitNot(Token node)
        {
            node.Values.Add("NOT");
            return node;
        }

        public override Node ExitIn(Token node)
        {
            node.Values.Add("IN");
            return node;
        }
        #endregion

        #region + Atoms
        public override Node ExitTrue(Token node)
        {
            node.Values.Add(true);
            return node;
        }

        public override Node ExitFalse(Token node)
        {
            node.Values.Add(false);
            return node;
        }

        public override Node ExitNull(Token node)
        {
            node.Values.Add(null);
            return node;
        }

        public override Node ExitInteger(Token node)
        {
            decimal val = node.Image.ParseToDecimal();
            node.Values.Add(val);
            return node;
        }

        public override Node ExitHex(Token node)
        {
            decimal val = node.Image.ParseToDecimal();
            node.Values.Add(val);
            return node;
        }

        public override Node ExitReal(Token node)
        {
            decimal val = node.Image.ParseToDecimal();
            node.Values.Add(val);
            return node;
        }

        public override Node ExitDatetime(Token node)
        {
            return base.ExitDatetime(node);
        }

        public override Node ExitChar(Token node)
        {
            node.Values.Add(node.Image[1]);
            return node;
        }

        public override Node ExitString(Token node)
        {
            node.Values.Add(node.Image);
            return node;
        }

        public override Node ExitIdentifier(Token node)
        {
            node.Values.Add(_variables[node.Image]);
            return node;
        }

        #endregion

        #region + Symbols
        public override Node ExitDot(Token node)
        {
            node.Values.Add(".");
            return node;
        }

        public override Node ExitComma(Token node)
        {
            node.Values.Add(",");
            return node;
        }

        public override Node ExitLeftBrace(Token node)
        {
            node.Values.Add("[");
            return node;
        }

        public override Node ExitRightBrace(Token node)
        {
            node.Values.Add("]");
            return node;
        }

        public override Node ExitLeftParen(Token node)
        {
            node.Values.Add("(");
            return node;
        }

        public override Node ExitRightParen(Token node)
        {
            node.Values.Add(")");
            return node;
        }
        #endregion

        #region + Comparisons
        public override Node ExitEq(Token node)
        {
            node.Values.Add("==");
            return node;
        }

        public override Node ExitNe(Token node)
        {
            node.Values.Add("!=");
            return node;
        }

        public override Node ExitGt(Token node)
        {
            node.Values.Add(">");
            return node;
        }

        public override Node ExitGe(Token node)
        {
            node.Values.Add(">=");
            return node;
        }

        public override Node ExitLt(Token node)
        {
            node.Values.Add("<");
            return node;
        }

        public override Node ExitLe(Token node)
        {
            node.Values.Add("<=");
            return node;
        }
        #endregion

        #region + Functions
        public override Node ExitDate(Token node)
        {
            node.Values.Add("DATE");
            return node;
        }

        public override Node ExitIf(Token node)
        {
            node.Values.Add("IF");
            return node;
        }

        public override Node ExitIfs(Token node)
        {
            node.Values.Add("IFS");
            return node;
        }
        #endregion
        #endregion

        #region Production
        public override Node ExitExpression(Production node)
        {
            node.Values.AddRange(GetChildValues(node));
            return node;
        }

        public override Node ExitLogicalExpression(Production node)
        {
            var values = GetChildValues(node);
            var expression = new LogicalExpression(values);
            node.Values.Add(expression.Result);
            return node;
        }

        public override Node ExitBooleanExpression(Production node)
        {
            var values = GetChildValues(node);
            var expression = new BooleanExpression(values);
            node.Values.Add(expression.Result);
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
    }
}
