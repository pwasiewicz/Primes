using System.Numerics;
using System.Threading.Tasks;
using BigPrimeNumber.Tools;

namespace BigPrimeNumber.Primality.Deterministic
{
    public class NaiveTest  : PrimalityTest
    {
        public override async Task<bool> TestAsync(BigInteger source)
        {
            var trivialCheck = await this.CheckEdgeCasesAsync(source);
            if (trivialCheck.HasValue) return trivialCheck.Value;

            var sourceSquareRoot = BigMath.SquareRoot(source);

            var isPrime = true;

            await Task.Run(() =>
            {
                for (var i = BigInteger.Zero; i <= sourceSquareRoot; i = BigInteger.Add(i, BigInteger.One))
                {
                    BigInteger rem;
                    BigInteger.DivRem(source, i, out rem);

                    if (rem == BigInteger.Zero) continue;

                    isPrime = false;
                    break;
                }
            });

            return isPrime;
        }
    }
}
