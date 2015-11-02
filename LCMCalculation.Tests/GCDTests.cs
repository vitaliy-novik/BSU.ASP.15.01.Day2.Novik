using System;
using NUnit.Framework;
using GCDCalculation;

namespace LCMCalculation.Tests
{
    [TestFixture]
    public class GCDTests
    {
        [TestCase(3, 5, Result = 1)]
        [TestCase(12, 78, Result = 6)]
        [TestCase(36, 12, Result = 12)]
        public int EuclideanAlgorithmTest(int a, int b)
        {
            long t;
            return (GCD.EuclideanAlgorithm(out t, a, b));
        }

        [TestCase(3, 5, Result = 1)]
        [TestCase(12, 78, Result = 6)]
        [TestCase(36, 12, Result = 12)]
        [TestCase(18200, 4340, Result = 140)]
        public int BinaryAlgorithmTest(int a, int b)
        {
            long t;
            return (GCD.BinaryAlgorithm(out t, a, b));
        }
    }

   
}
