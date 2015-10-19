using System;
using NUnit.Framework;
using CustomerFormatting;

namespace CustomerFormatting.Tests
{
    [TestFixture]
    public class CustomerTests
    {
        [TestCase("+1(123)233-4324", Result="+1 (123) 233-4324")]
        [TestCase("1(123)233-4324", Result = "+1 (123) 233-4324")]
        [TestCase("+375 (29) 233-4324", Result = "+375 (29) 233-4324")]
        [TestCase("+1(123)2353-4324", ExpectedException=typeof(ArgumentException))]
        public string ContactPhoneTest(string phone)
        {
            Customer c = new Customer();
            c.ContactPhone = phone;
            return (c.ContactPhone);
        }
    }
}
