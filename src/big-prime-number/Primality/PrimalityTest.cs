using System.Numerics;
using System.Threading.Tasks;
using BigPrimeNumber.Helpers;
using BigPrimeNumber.Randomness;

namespace BigPrimeNumber.Primality
{
    public abstract class PrimalityTest : IPrimalityTest
    {
        internal IRandomProvider RandomProviderInternal { private get; set; } = new SimpleRandomProvider();

        protected IRandomProvider RandomProvider => this.RandomProviderInternal;

        protected async Task<BigInteger> RandomIntegerBelowAsync(BigInteger max)
        {
            var bytes = max.ToByteArray();
            BigInteger result;

            await Task.Run(() =>
            {
                do
                {
                    this.RandomProvider.NextBytes(bytes);
                    bytes[bytes.Length - 1] &= 0x7F;
                    result = new BigInteger(bytes);
                } while (result >= max || result.Equals(BigIntegerHelpers.One) || result.Equals(BigIntegerHelpers.Zero));
            });

            return result;
        }

        public abstract Task<bool> TestAsync(BigInteger source);
    }
}
