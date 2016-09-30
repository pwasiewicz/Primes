using System;

namespace BigPrimeNumber.Randomness
{
    public sealed class SimpleRandomProvider : IRandomProvider
    {
        private static readonly Lazy<Random> RandomHolder = new Lazy<Random>(() => new Random());

        private static Random Random => RandomHolder.Value;

        public void NextBytes(byte[] buffer)
        {
            Random.NextBytes(buffer);
        }
    }
}
