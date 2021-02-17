using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CompoundOperations.Extensions
{
    public static class StringToDateTimeExtension
    {
        public static DateTime ParseToDateTime(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return default;
            }

            DateTime dateTime;
            input = input.Trim();
            Regex regex = new Regex("^#([^#]+)#$");
            Match match = regex.Match(input);
            if (match.Success
                && DateTime.TryParse(match.Groups[1].Value, out dateTime))
            {
                return dateTime;
            }

            throw new FormatException($"{input} is not a correct datetime format");
        }
    }
}
