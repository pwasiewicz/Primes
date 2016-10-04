namespace BigPrimeNumber.Randomness
{
    public interface IRandomProvider
    {
        /// <summary>
        /// Fills buffer with random bytes.
        /// </summary>
        /// <param name="buffer">Buffer that should be filled with random bytes.</param>
        void NextBytes(byte[] buffer);

        /// <summary>
        /// Gets random integer number.
        /// </summary>
        /// <param name="maxExclusive">Maximum range</param>
        /// <returns>Random int number.</returns>
        int NextInt(int maxExclusive);
    }
}
