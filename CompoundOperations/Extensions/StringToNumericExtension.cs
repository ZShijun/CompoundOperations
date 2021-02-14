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
        /// 将数字字符串转成decimal
        /// </summary>
        /// <param name="input">数字字符串</param>
        /// <returns></returns>
        public static decimal ParseToDecimal(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return default;
            }
            decimal result = 0M;
            input = input.Trim();
            if (input.IsNumber())
            {
                result = decimal.Parse(input);
            }
            else if (input.IsHexNumber())
            {
                input = input[2..];
                long num = long.Parse(input, NumberStyles.HexNumber);
                result = Convert.ToDecimal(num);
            }
            else if (input.IsRealNumber())
            {
                result = decimal.Parse(input, NumberStyles.Float);
            }
            else
            {
                throw new FormatException($"{input} is not a correct number");
            }

            return result;
        }

        /// <summary>
        /// 是否为十六进制数字字符串
        /// </summary>
        /// <param name="input">数字字符串</param>
        /// <returns></returns>
        public static bool IsHexNumber(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            input = input.Trim();
            Regex regex = new Regex("^0[Xx][0-9a-fA-F]+$");
            return regex.IsMatch(input);
        }

        /// <summary>
        /// 是否为十进制数字字符串
        /// </summary>
        /// <param name="input">数字字符串</param>
        /// <returns></returns>
        public static bool IsNumber(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            input = input.Trim();
            Regex regex = new Regex("^\\d+$");
            return regex.IsMatch(input);
        }

        /// <summary>
        /// 是否为浮点数
        /// </summary>
        /// <param name="input">数字字符串</param>
        /// <returns></returns>
        public static bool IsRealNumber(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            input = input.Trim();
            Regex regex = new Regex("^\\d+\\.\\d+([Ee][+-]?\\d+)?$");
            return regex.IsMatch(input);
        }
    }
}
