using System.Numerics;
using System.Threading.Tasks;
using BigPrimeNumber.Helpers;

namespace BigPrimeNumber.Primality.Heuristic
{
    public class FermatTest : IPrimalityTest
    {
        private readonly uint complexity;

        public FermatTest(uint complexity)
        {
            this.complexity = complexity;
        }

        public async Task<bool> TestAsync(BigInteger source)
        {
            var trivialCheck = await BigIntegerHelpers.TrivialCheckAsync(source);
            if (trivialCheck.HasValue) return trivialCheck.Value;

            for (var i = 0; i < this.complexity; i++)
            {
                var randomNumber = await BigIntegerHelpers.RandomIntegerBelowAsync(source);
                randomNumber = BigInteger.ModPow(randomNumber, BigInteger.Subtract(source, BigIntegerHelpers.One),
                    source);

                if (!randomNumber.Equals(BigIntegerHelpers.One)) return false;
            }

            return true;
        }
    }
}
