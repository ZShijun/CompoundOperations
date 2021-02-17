using CompoundOperations.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CompoundOperations.Expressions
{
    public class ComparisonExpression : BinaryExpression
    {
        public ComparisonExpression(ArrayList elements) : base(elements)
        {
        }

        protected override object Calculate(object left, string op, object right)
        {
            if (left is IEnumerable
                || right is IEnumerable)
            {
                return ArrayListCompare(left, op, right);
            }

            string leftTypeName = left.GetType().Name;
            string rightTypeName = right.GetType().Name;
            if (leftTypeName != rightTypeName)
            {
                throw new NotSupportedException($"{leftTypeName}[{left}] and {rightTypeName}[{right}] can not be compared.");
            }

            return leftTypeName switch
            {
                "Decimal" => DecimalCompare(left, op, right),
                "DateTime" => DateTimeCompare(left, op, right),
                "Char" => CharCompare(left, op, right),
                "String" => StringCompare(left, op, right),
                _ => throw new NotSupportedException("not supported comparison."),
            };
        }

        private bool DecimalCompare(object left, string op, object right)
        {
            decimal x = Convert.ToDecimal(left);
            decimal y = Convert.ToDecimal(right);
            return op switch
            {
                "=" => x == y,
                "<>" => x != y,
                ">" => x > y,
                "<" => x < y,
                ">=" => x >= y,
                "<=" => x <= y,
                _ => throw new NotSupportedException("unknown numeric comparison operator: " + op),
            };
        }

        private bool DateTimeCompare(object left, string op, object right)
        {
            DateTime x = Convert.ToDateTime(left);
            DateTime y = Convert.ToDateTime(right);
            return op switch
            {
                "=" => x == y,
                "<>" => x != y,
                ">" => x > y,
                "<" => x < y,
                ">=" => x >= y,
                "<=" => x <= y,
                _ => throw new NotSupportedException("unknown datetime comparison operator: " + op),
            };
        }

        private bool CharCompare(object left, string op, object right)
        {
            char x = Convert.ToChar(left);
            char y = Convert.ToChar(right);
            return op switch
            {
                "=" => x == y,
                "<>" => x != y,
                ">" => x > y,
                "<" => x < y,
                ">=" => x >= y,
                "<=" => x <= y,
                _ => throw new NotSupportedException("unknown char comparison operator: " + op),
            };
        }

        private bool StringCompare(object left, string op, object right)
        {
            string x = left.ToString();
            string y = right.ToString();
            return op switch
            {
                "=" => x == y,
                "<>" => x != y,
                _ => throw new NotSupportedException("unknown string comparison operator: " + op),
            };
        }

        private bool ArrayListCompare(object left, string op, object right)
        {
            var leftList = left.ToDistinctStringList();
            var rightList = right.ToDistinctStringList();
            var intersect = leftList.Intersect(rightList);

            return op switch
            {
                "=" => leftList.Count() == rightList.Count()
                && leftList.Count() == intersect.Count(),
                "<>" => leftList.Count() != rightList.Count()
                || leftList.Count() != intersect.Count(),
                _ => throw new NotSupportedException("unknown string comparison operator: " + op),
            };
        }
    }
}
