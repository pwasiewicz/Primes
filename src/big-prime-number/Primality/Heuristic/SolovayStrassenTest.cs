using System;
using System.Numerics;
using System.Threading.Tasks;

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
                var ec = EulerCriterion(source, randomNum);
                var jc = await JacobiAsync(randomNum, source);

                if (ec != jc) return false;
            }

            return true;
        }

        private static Task<int> JacobiAsync(BigInteger m, BigInteger n)
        {
            return Task.Run(async () =>
            {
                while (true)
                {
                    if (m.CompareTo(n) >= 0)
                    {
                        m = m%n;
                        continue;
                    }

                    if (n == BigInteger.One || m == BigInteger.One)
                    {
                        return 1;
                    }

                    if (m == BigInteger.Zero)
                    {
                        return 0;
                    }

                    var twoCount = 0;

                    while (m%2 == BigInteger.Zero)
                    {
                        twoCount++;
                        m = m/2;
                    }

                    var j2N = (n%8).Equals(BigInteger.One) || (n%8).Equals(7) ? 1 : -1;

                    var rule8Multiplier = twoCount%2 == 0 ? 1 : j2N;

                    var tmp =  await JacobiAsync(n, m);
                    var rule6Multiplier = (n%4).Equals(BigInteger.One) || (m%4).Equals(BigInteger.One) ? 1 : -1;

                    return tmp*rule6Multiplier*rule8Multiplier;
                }
            });
        }

        private static int EulerCriterion(BigInteger p, BigInteger a)
        {
            var exponent = (p - 1)/2;
            var x = BigInteger.ModPow(a, exponent, p); 

            if (x.Equals(BigInteger.Zero) || x.Equals(BigInteger.One))
            {
                return (int) x;
            }

            var y = (x + 1)%p;
            return y.Equals(BigInteger.Zero) ? -1 : 2;
        }

    }
}
