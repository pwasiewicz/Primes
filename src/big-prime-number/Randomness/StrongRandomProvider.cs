using System;
using System.Security.Cryptography;

namespace BigPrimeNumber.Randomness
{
    public class StrongRandomProvider : IRandomProvider
    {
        private static readonly Lazy<RandomNumberGenerator> RandomHolder =
            new Lazy<RandomNumberGenerator>(RandomNumberGenerator.Create);


        private static readonly Lazy<Random> FastRandomHolder = new Lazy<Random>(() => new Random());

        public void NextBytes(byte[] buffer)
        {
            RandomHolder.Value.GetBytes(buffer);
        }

        public int NextInt(int maxExclusive)
        {
            return FastRandomHolder.Value.Next(maxExclusive);
        }
    }
}
