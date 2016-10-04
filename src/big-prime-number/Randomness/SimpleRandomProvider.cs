using System;

namespace BigPrimeNumber.Randomness
{
    public sealed class SimpleRandomProvider : IRandomProvider
    {
        private static readonly Lazy<Random> RandomHolder = new Lazy<Random>(() => new Random());

        public void NextBytes(byte[] buffer)
        {
            RandomHolder.Value.NextBytes(buffer);
        }

        public int NextInt(int maxExclusive)
        {
            return RandomHolder.Value.Next(maxExclusive);
        }
    }
}
