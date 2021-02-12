using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace CompoundOperations.Extensions
{
    public static class StringToNumericExtension
    {
        /// <summary>
        /// 将十进制整数字字符串(包括有符号整型，无符号整型，有符号长整型和无符号长整型)转成decimal
        /// </summary>
        /// <param name="input">整数字符串(格式：\d+(u|l|ul|lu)?)</param>
        /// <returns></returns>
        public static decimal ParseDecIntToDecimal(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return default;
            }

            if (!input.IsNegativeInteger()
               && !input.IsNonnegativeInteger())
            {
                throw new FormatException($"{input} is not a correct integer format");
            }

            string number = input.Trim(' ', 'u', 'l', 'U', 'L');
            return decimal.Parse(number);
        }

        public static bool IsNegativeInteger(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            input = input.Trim();
            Regex regex = new Regex("^(-\\d+)[lL]?$");
            return regex.IsMatch(input);
        }

        public static bool IsNonnegativeInteger(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            input = input.Trim();
            Regex regex = new Regex("^(\\d+)([lL]|[uU]|[uU][lL]|[lL][uU])?$");
            Match match = regex.Match(input);
            return regex.IsMatch(input);
        }
    }
}
