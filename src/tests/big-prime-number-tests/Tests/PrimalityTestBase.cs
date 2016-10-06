using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Numerics;
using Xunit;

namespace BigPrimeNumberTests.Tests
{
    public abstract class PrimalityTestBase
    {
        private static readonly Random Rnd = new Random();

        public static IEnumerable<object[]> PrimeNumbersArguments => GetPrimeNumbers().Select(pr => new object[] {pr});

        public static IEnumerable<object[]> GeneratedCompositeNumbers => GetCompositeNumbers().Select(pr => new object[] { pr });


        protected static IEnumerable<long> GetCompositeNumbers()
            => new long[] {2*3, 839*173, 421*421*991*5, 271*379, 1, 751*97*101, 101*599*953, 397*167*2*5};

        private static IEnumerable<int> GetPrimeNumbers() => new[]
        {
            2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 101,
            409, 419, 421, 431,
            823, 827, 829, 839,
            883, 887, 907, 911, 983, 991, 997
        };

        public static BigInteger BigKnownNumber()
        {
            return BigInteger.Parse("20988936657440586486151264256610222593863921");
        }
    }
}
