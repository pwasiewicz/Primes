namespace BigPrimeNumber.Randomness
{
    public interface IRandomProvider
    {
        /// <summary>
        /// Fills buffer with random bytes.
        /// </summary>
        /// <param name="buffer">Buffer that should be filled with random bytes.</param>
        void NextBytes(byte[] buffer);
    }
}
