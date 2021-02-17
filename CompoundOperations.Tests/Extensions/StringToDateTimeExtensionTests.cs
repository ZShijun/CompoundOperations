using CompoundOperations.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CompoundOperations.Tests.Extensions
{
    public class StringToDateTimeExtensionTests
    {
        [Theory]
        [InlineData("#2021-1-1#", "2021-1-1 00:00:00")]
        [InlineData("#2021年1月1日#", "2021-1-1 00:00:00")]
        [InlineData("#2021/1/1#", "2021-1-1 00:00:00")]
        [InlineData("#2021/1/1 23:00:00#", "2021-1-1 23:00:00")]
        [InlineData("#2021-1-1 23:30:30#", "2021-1-1 23:30:30")]
        public void ParseToDateTime_ShouldBeExpectedDateTime_WhenGivenFormatDateTimeString(string input,string expectedDateTime)
        {
            DateTime expected = DateTime.Parse(expectedDateTime);
            Assert.Equal(expected, input.ParseToDateTime());
        }

        [Theory]
        [InlineData("2021-1-1")]
        [InlineData("2021-1-1#")]
        [InlineData("#2021-1-1 23#")]
        [InlineData("#123#")]
        [InlineData("#2021-1-1 25:00:00#")]
        public void ParseToDateTime_ShouldThrowFormatException_WhenNonFormatDateTimeString(string input)
        {
            var ex = Assert.Throws<FormatException>(() =>
            {
                input.ParseToDateTime();
            });

            Assert.Equal($"{input} is not a correct datetime format", ex.Message);
        }
    }
}
