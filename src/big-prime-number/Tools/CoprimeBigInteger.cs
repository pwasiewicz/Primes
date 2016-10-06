using System;
using System.Numerics;
using System.Threading.Tasks;
using BigPrimeNumber.Helpers;

namespace BigPrimeNumber.Tools
{
    public static class CoprimeBigInteger
    {
        public static Task<bool> AreCoprimeAsync(BigInteger x, BigInteger y)
        {
            return Task.Run(() => BigInteger.GreatestCommonDivisor(x, y) == BigIntegerHelpers.One);
        }

        public static Task<BigInteger> EulerTotientAsync(BigInteger n)
        {
            if (n < 0) throw new ArgumentOutOfRangeException(nameof(n), "n should be above 0");

            return Task.Run(() =>
            {
                var sum = BigIntegerHelpers.Zero;
                for (var i = BigInteger.Zero; i < n; i++)
                    if (BigInteger.GreatestCommonDivisor(i, n) == 1) sum++;

                return sum;
            });
        }
    }
}
