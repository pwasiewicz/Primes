using System;
using System.Threading.Tasks;
using BigPrimeNumber.Primality;

namespace BigPrimeNumber
{
    using System.Numerics;

    public static class BigIntegerExtensions
    {
        public static Task<bool> IsPrime(this BigInteger source, IPrimalityTest primalityTest)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (primalityTest == null) throw new ArgumentNullException(nameof(primalityTest));

            return primalityTest.TestAsync(source);
        }
    }

    public enum PrimeCheckComplexity
    {
        Fast,
        Normal,
        Hard
    }
}
