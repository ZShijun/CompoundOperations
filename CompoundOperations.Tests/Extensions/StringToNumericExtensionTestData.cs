using System;
using System.Collections.Generic;
using System.Text;

namespace CompoundOperations.Tests.Extensions
{
    public class StringToNumericExtensionTestData
    {
        public static readonly IEnumerable<object[]> NegativeIntegers = new List<object[]>
        {
            new object[]{ "-1" },
            new object[]{ "-1l" },
            new object[]{ "-9223372036854775809" },
            new object[]{ "-9223372036854775809l" }
        };

        public static readonly IEnumerable<object[]> NonnegativeIntegers = new List<object[]>
        {
            new object[]{ "0" },
            new object[]{ "0l" },
            new object[]{ "0u" },
            new object[]{ "0lU" },
            new object[]{ "0Ul" },
            new object[]{ "9223372036854775809" },
            new object[]{ "9223372036854775809l" },
            new object[]{ "    9223372036854775809u" },
            new object[]{ "9223372036854775809Lu" },
            new object[]{ "9223372036854775809uL  " }
        };

        public static readonly IEnumerable<object[]> Integers = new List<object[]>
        {
            new object[]{ "0" ,0},
            new object[]{ "0l" ,0},
            new object[]{ "0u" ,0},
            new object[]{ "0lU" ,0},
            new object[]{ "0Ul" ,0},
            new object[]{ "9223372036854775809",9223372036854775809M },
            new object[]{ "9223372036854775809l",9223372036854775809M },
            new object[]{ "    9223372036854775809u" ,9223372036854775809M},
            new object[]{ "9223372036854775809Lu" ,9223372036854775809M},
            new object[]{ "9223372036854775809uL  " ,9223372036854775809M},
            new object[]{ "-1",-1 },
            new object[]{ "-1l", -1},
            new object[]{ "-9223372036854775809" ,-9223372036854775809M},
            new object[]{ "-9223372036854775809l", -9223372036854775809M }
        };

        public static readonly IEnumerable<object[]> NonIntegers = new List<object[]>
        {
            new object[]{ "9223372036854775809uu" },
            new object[]{ "9223372036854775809ll" },
            new object[]{ "-9223372036854775809u" },
            new object[]{ "-9223372036854775809lu" },
            new object[]{ "-9223372036854775809ul" },
            new object[]{ "a12" },
            new object[]{ "12a" },
            new object[]{ "0x9f" },
            new object[]{ "1.00" }
        };
    }
}
