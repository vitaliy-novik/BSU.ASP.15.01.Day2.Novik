using NUnit.Framework;
using System;

namespace HexadecimalExtension.Tests
{
    [TestFixture]
    public class HexadecimalConverterTests
    {
        [TestCase(int.MaxValue)]
        [TestCase(0)]
        [TestCase(2983)]
        public void ToHexadecimalTest(int value)
        {
            string expected = Convert.ToString(value, 16);
            string actual = value.ToHexadecimal();
            StringAssert.AreEqualIgnoringCase(expected, actual);
        }

        static int[] TestValues = { int.MaxValue, 0, 24655};
    }
}
