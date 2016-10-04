using System;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace BigPrimeNumber.Helpers
{
    internal class BigIntegerHelpers
    {
        public static readonly BigInteger Zero = BigInteger.Zero;
        public static readonly BigInteger One = BigInteger.One;
        public static readonly BigInteger Two = new BigInteger(2);

        public static bool? TrivialCheck(BigInteger source)
        {
            if (source.Sign < 0) throw new ArgumentOutOfRangeException(nameof(source), "Source number must be a positive.");

            if (source.Equals(One) || source.Equals(Zero))
                return false;
            if (source.Equals(Two)) return true;

            if (source.IsEven) return false;

            if (source < 1000)
            {
                return PrimeNumbers.KnownPrimes.Contains((int) source);
            }

            return PrimeNumbers.KnownPrimes.Any(p => BigInteger.Remainder(source, p) == 0)
                ? false
                : (bool?)null;
        }
    }
}
