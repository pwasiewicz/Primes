using System;
using System.Numerics;
using System.Threading.Tasks;
using BigPrimeNumber.Primality;
using BigPrimeNumber.Primality.Heuristic;
using BigPrimeNumber.Randomness;

namespace BigPrimeNumber.Tools
{
    public static class PrimaryBigInteger
    {
        public static async Task<BigInteger> GeneratePrime(uint bitLength, IRandomProvider randomProvider, IPrimalityTest primalityTest)
        {
            if (randomProvider == null) throw new ArgumentNullException(nameof(randomProvider));
            if (bitLength < 8) throw new ArgumentOutOfRangeException(nameof(bitLength), "Bit length must be at least of length 8.");

            var bytes = bitLength/8;

            var randomNumberBytes = new byte[bytes];
            randomProvider.NextBytes(randomNumberBytes);

            var result = new BigInteger(randomNumberBytes);

            if (result.Sign < 0)
            {
                result = BigInteger.Negate(result);
            }

            if (result.IsEven)
            {
                result = result + 1;
            }

            while (!await primalityTest.TestAsync(result))
            {
                result = result + 2;
            }

            return result;
        }

        public static Task<BigInteger> GenerateProbablyPrime(uint bitLength, IRandomProvider randomProvider)
        {
            return GeneratePrime(bitLength, randomProvider, new RobinMillerTest(bitLength/2));
        }

        public static Task<BigInteger> GenerateProbablyPrime(uint bitLength)
        {
            return GeneratePrime(bitLength, new StrongRandomProvider(), new RobinMillerTest(bitLength/2));
        }
    }
}
