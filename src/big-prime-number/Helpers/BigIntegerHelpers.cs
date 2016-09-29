using System;
using System.Numerics;
using System.Threading.Tasks;

namespace BigPrimeNumber.Helpers
{
    public class BigIntegerHelpers
    {
        public static readonly BigInteger Zero = BigInteger.Zero;
        public static readonly BigInteger One = BigInteger.One;
        public static readonly BigInteger Two = new BigInteger(2);

        public static async Task<BigInteger> RandomIntegerBelowAsync(BigInteger max)
        {
            var bytes = max.ToByteArray();
            BigInteger result;

            await Task.Run(() =>
            {
                do
                {
                    RandomHelpers.Rnd.NextBytes(bytes);
                    bytes[bytes.Length - 1] &= 0x7F;
                    result = new BigInteger(bytes);
                } while (result >= max);
            });
            
            return result;
        }

        public static Task<bool?> TrivialCheckAsync(BigInteger source)
        {
            if (source.Sign < 0) throw new ArgumentOutOfRangeException(nameof(source));

            if (source.Equals(One) || source.Equals(Zero))
                return Task.FromResult(new bool?(false));
            if (source.Equals(Two)) return Task.FromResult(new bool?(true));

            if (source.IsEven) return Task.FromResult(new bool?(false));

            return Task.FromResult<bool?>(null);
        }
    }
}
