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
        [MemberData(nameof(StringToNumericExtensionTestData.NonnegativeIntegers),
           MemberType = typeof(StringToNumericExtensionTestData))]
        public void IsNegativeInteger_ShouldBeFalse_WhenGivenNonnegativeIntegerString(string input)
        {
            Assert.False(input.IsNegativeInteger());
        }

        [Theory]
        [MemberData(nameof(StringToNumericExtensionTestData.NonnegativeIntegers),
           MemberType = typeof(StringToNumericExtensionTestData))]
        public void IsNonnegativeInteger_ShouldBeTrue_WhenGivenNonnegativeIntegerString(string input)
        {
            Assert.True(input.IsNonnegativeInteger());
        }

        [Theory]
        [MemberData(nameof(StringToNumericExtensionTestData.NegativeIntegers),
           MemberType = typeof(StringToNumericExtensionTestData))]
        public void IsNegativeInteger_ShouldBeTrue_WhenGivenNegativeIntegerString(string input)
        {
            Assert.True(input.IsNegativeInteger());
        }

        [Theory]
        [MemberData(nameof(StringToNumericExtensionTestData.NegativeIntegers),
           MemberType = typeof(StringToNumericExtensionTestData))]
        public void IsNonnegativeInteger_ShouldBeFalse_WhenGivenNegativeIntegerString(string input)
        {
            Assert.False(input.IsNonnegativeInteger());
        }

        [Theory]
        [MemberData(nameof(StringToNumericExtensionTestData.NonIntegers),
           MemberType = typeof(StringToNumericExtensionTestData))]
        public void IsNonnegativeInteger_ShouldBeFalse_WhenGivenNonIntegerString(string input)
        {
            Assert.False(input.IsNonnegativeInteger());
        }

        [Theory]
        [MemberData(nameof(StringToNumericExtensionTestData.NonIntegers),
           MemberType = typeof(StringToNumericExtensionTestData))]
        public void IsNegativeInteger_ShouldBeFalse_WhenGivenNonIntegerString(string input)
        {
            Assert.False(input.IsNegativeInteger());
        }

        [Theory]
        [MemberData(nameof(StringToNumericExtensionTestData.Integers),
           MemberType = typeof(StringToNumericExtensionTestData))]
        public void ParseDecIntToDecimal_ShouldGetDecimalValue_WhenGivenIntegerString(string input, decimal expected)
        {
            Assert.Equal(expected, input.ParseDecIntToDecimal());
        }

        [Theory]
        [MemberData(nameof(StringToNumericExtensionTestData.NonIntegers),
           MemberType = typeof(StringToNumericExtensionTestData))]
        public void ParseDecIntToDecimal_ShouldThrow_WhenGivenNonIntegerString(string input)
        {
            var ex = Assert.Throws<FormatException>(() =>
            {
                input.ParseDecIntToDecimal();
            });

            Assert.Equal($"{input} is not a correct integer format", ex.Message);
        }
    }
}
