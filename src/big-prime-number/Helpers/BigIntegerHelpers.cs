using System;
using System.Numerics;
using System.Threading.Tasks;

namespace BigPrimeNumber.Helpers
{
    internal class BigIntegerHelpers
    {
        public static readonly BigInteger Zero = BigInteger.Zero;
        public static readonly BigInteger One = BigInteger.One;
        public static readonly BigInteger Two = new BigInteger(2);

        public static Task<bool?> TrivialCheckAsync(BigInteger source)
        {
            if (source.Sign < 0) throw new ArgumentOutOfRangeException(nameof(source), "Source number must be a positive.");

            if (source.Equals(One) || source.Equals(Zero))
                return Task.FromResult(new bool?(false));
            if (source.Equals(Two)) return Task.FromResult(new bool?(true));

            if (source.IsEven) return Task.FromResult(new bool?(false));

            if (source < 1000)
            {
                return Task.FromResult(new bool?(PrimeNumbers.KnownPrimes.Contains((int) source)));
            }

            return Task.FromResult<bool?>(null);
        }
    }
}
