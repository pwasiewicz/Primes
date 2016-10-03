using System;
using System.Numerics;
using System.Threading.Tasks;
using BigPrimeNumber.Helpers;

namespace BigPrimeNumber.Primality.Heuristic
{
    public class SolovayStrassenTest : PrimalityTest
    {
        private readonly int complexity;

        public SolovayStrassenTest(int complexity)
        {

            if (complexity == 0)
                throw new ArgumentOutOfRangeException(nameof(complexity), "Complexity must be above 0.");

            this.complexity = complexity;
        }

        public override async Task<bool> TestAsync(BigInteger source)
        {
            var trivialCheck = await this.CheckEdgeCasesAsync(source);
            if (trivialCheck.HasValue) return trivialCheck.Value;

            for (var k = this.complexity; k > 0; k--)
            {
                var randomNum = await this.RandomIntegerBelowAsync(source);
                var jacobiResult = await JacobiAsync(randomNum, source);

                if (jacobiResult == 0 || BigInteger.ModPow(randomNum, BigInteger.Divide(BigInteger.Subtract(source, 1), 2), source)  != jacobiResult % source)
                {
                    return false;
                }
            }

            return true;
        }

        private static async Task<BigInteger> JacobiAsync(BigInteger a, BigInteger n)
        {
            BigInteger mul = 1;

            if (BigInteger.Remainder(n, 2) == 0)
            {
                return BigIntegerHelpers.Two;
            }

            if (BigInteger.GreatestCommonDivisor(a, n) != 1)
            {
                return BigIntegerHelpers.Zero;
            }

            await Task.Run(() =>
            {
                while (a != 0)
                {
                    while (BigInteger.Remainder(a, 2) == BigIntegerHelpers.Zero)
                    {
                        a = BigInteger.Divide(a, 2);

                        if (BigInteger.Remainder(n, 8) == 3 || BigInteger.Remainder(n, 8) == 5)
                        {
                            mul = BigInteger.Negate(mul);
                        }
                    }

                    var temp = a;

                    a = n;
                    n = temp;
                    a = BigInteger.Remainder(a, n);

                    if ((BigInteger.Remainder(a, 4) == 3) && (BigInteger.Remainder(a, 4) == 3))
                    {
                        mul = BigInteger.Negate(mul);
                    }
                }
            });

            return n == BigIntegerHelpers.One ? mul : BigIntegerHelpers.Zero;
        }
    }
}
