using CompoundOperations.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CompoundOperations.Tests.Extensions
{
    public class StringToNumericExtensionTests
    {
        [Theory]
        [InlineData("a123", false)]
        [InlineData("123b", false)]
        [InlineData("-1", false)]
        [InlineData("0", true)]
        [InlineData("001", true)]
        [InlineData("18446744073709551615", true)]
        [InlineData("18446744073709551616", true)]
        [InlineData("0x12af", false)]
        [InlineData("12af", false)]
        [InlineData("1.1", false)]
        [InlineData("1.1e+3", false)]
        public void IsNumber_ShouldBeExpectedBoolean_WhenGivenAString(string input, bool expected)
        {
            Assert.Equal(expected, input.IsNumber());
        }

        [Theory]
        [InlineData("a123", false)]
        [InlineData("123b", false)]
        [InlineData("-1", false)]
        [InlineData("0", false)]
        [InlineData("18446744073709551615", false)]
        [InlineData("0x12af", true)]
        [InlineData("0X12af", true)]
        [InlineData("12af", false)]
        [InlineData("0X0", true)]
        [InlineData("-0X0", false)]
        [InlineData("0xffffffffffffffff", true)]
        [InlineData("0x10000000000000000", true)]
        [InlineData("1.1", false)]
        [InlineData("1.1e+3", false)]
        public void IsHexNumber_ShouldBeExpectedBoolean_WhenGivenAString(string input, bool expected)
        {
            Assert.Equal(expected, input.IsHexNumber());
        }

        [Theory]
        [InlineData("a123", false)]
        [InlineData("123b", false)]
        [InlineData("-1", false)]
        [InlineData("0", false)]
        [InlineData("0.0", true)]
        [InlineData("18446744073709551615", false)]
        [InlineData("0x12af", false)]
        [InlineData("1.1", true)]
        [InlineData("-1.1", false)]
        [InlineData("1.1e+3", true)]
        [InlineData("1.1e-3", true)]
        public void IsRealNumber_ShouldBeExpectedBoolean_WhenGivenAString(string input, bool expected)
        {
            Assert.Equal(expected, input.IsRealNumber());
        }

        [Theory]
        [InlineData("0", 0)]
        [InlineData("0.0", 0)]
        [InlineData("18446744073709551615", 18446744073709551615)]
        [InlineData("0xffffffffffffffff", 18446744073709551615)]
        [InlineData("0x12af", 4783)]
        [InlineData("1.1", 1.1)]
        [InlineData("1.1e+3", 1100)]
        [InlineData("1.1e-3", 0.0011)]
        public void ParseToDecimal_ShouldBeExpectedDecimal_WhenGivenNumericString(string input, decimal expected)
        {
            Assert.Equal(expected, input.ParseToDecimal());
        }

        [Theory]
        [InlineData("a123")]
        [InlineData("123b")]
        [InlineData("-1")]
        [InlineData("0x12ag")]
        [InlineData("-0x12af")]
        [InlineData("-1.1")]
        public void ParseToDecimal_ShouldThrowFormatException_WhenNotANumericString(string input)
        {
            var ex = Assert.Throws<FormatException>(() =>
            {
                input.ParseToDecimal();
            });

            Assert.Equal($"{input} is not a correct number format", ex.Message);
        }

        [Theory]
        [InlineData("0x10000000000000000")]
        [InlineData("79228162514264337593543950336")]
        [InlineData("8.0e+28")]
        public void ParseToDecimal_ShouldThrowOverflowException_WhenGivenOverflowNumericString(string input)
        {
            Assert.Throws<OverflowException>(() =>
            {
                input.ParseToDecimal();
            });
        }
    }
}
