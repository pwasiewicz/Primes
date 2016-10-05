using System;

namespace BigPrimeNumber.Randomness
{
    public sealed class SimpleRandomProvider : IRandomProvider
    {
        private static readonly Lazy<Random> RandomHolder = new Lazy<Random>(() => new Random());
        private static readonly object RandomAccess = new object();

        public void NextBytes(byte[] buffer)
        {
            lock (RandomAccess)
            {
                RandomHolder.Value.NextBytes(buffer);
            }
        }

        public int NextInt(int maxExclusive)
        {
            lock (RandomAccess)
            {
                return RandomHolder.Value.Next(maxExclusive);
            }
        }
    }
}
