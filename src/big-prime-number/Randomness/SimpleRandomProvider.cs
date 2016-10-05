using System;

namespace BigPrimeNumber.Randomness
{
    public sealed class SimpleRandomProvider : IRandomProvider
    {
        [ThreadStatic] private static Random _random;

        private static Random RandomInstance
        {
            get
            {
                if (_random == null) _random = new Random();

                return _random;
            }
        }
        
        public void NextBytes(byte[] buffer)
        {
            RandomInstance.NextBytes(buffer);
        }

        public int NextInt(int maxExclusive)
        {
            return RandomInstance.Next(maxExclusive);
        }
    }
}
