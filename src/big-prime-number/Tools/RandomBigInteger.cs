using System;
using System.Numerics;
using System.Threading.Tasks;
using BigPrimeNumber.Helpers;
using BigPrimeNumber.Randomness;

namespace BigPrimeNumber.Tools
{
    public static class RandomBigInteger
    {
        public static Task<BigInteger> GenerateAsync(BigInteger maxExclusive)
        {
            return GenerateAsync(maxExclusive, new SimpleRandomProvider());
        }

        public static async Task<BigInteger> GenerateAsync(BigInteger maxExclusive, IRandomProvider randomProvider)
        {
            if (randomProvider == null) throw new ArgumentNullException(nameof(randomProvider));
            if (maxExclusive == BigIntegerHelpers.Zero)
                throw new ArgumentOutOfRangeException(nameof(maxExclusive), "Max exclusive must be above 0.");

            if (maxExclusive == BigIntegerHelpers.One)
                return BigInteger.Zero;

            if (maxExclusive < new BigInteger(int.MaxValue))
            {
                return new BigInteger(randomProvider.NextInt((int) maxExclusive));
            }

            var bytes = maxExclusive.ToByteArray();
            BigInteger result;

            await Task.Run(() =>
            {
                do
                {
                    randomProvider.NextBytes(bytes);
                    bytes[bytes.Length - 1] &= 0x7F;
                    result = new BigInteger(bytes);
                } while (result >= maxExclusive || result.Equals(BigIntegerHelpers.One) || result.Equals(BigIntegerHelpers.Zero));
            });

            return result;
        }
    }
}
