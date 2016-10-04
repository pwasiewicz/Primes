using System;
using System.Numerics;
using System.Threading.Tasks;

namespace BigPrimeNumber.Primality.Heuristic
{
    public class RobinMillerTest : PrimalityTest
    {
        private readonly uint complexity;

        public RobinMillerTest(uint complexity)
        {
            if (complexity == 0)
                throw new ArgumentOutOfRangeException(nameof(complexity), "Complexity must be above 0.");

            this.complexity = complexity;
        }

        public override async Task<bool> TestAsync(BigInteger source)
        {
            var trivialCheck = this.CheckEdgeCases(source);
            if (trivialCheck.HasValue) return trivialCheck.Value;

            var d = source - 1;
            var s = 0;

            while (d%2 == 0)
            {
                d /= 2;
                s += 1;
            }

            for (var i = 0; i < this.complexity; i++)
            {
                var a = await RandomIntegerBelowAsync(source);

                var x = BigInteger.ModPow(a, d, source);
                if (x == 1 || x == source - 1)
                {
                    continue;
                }

                for (var r = 1; r < s; r++)
                {
                    x = BigInteger.ModPow(x, 2, source);
                    if (x == 1)
                    {
                        return false;
                    }

                    if (x == source - 1)
                    {
                        break;
                    }
                }

                if (x != source - 1)
                    return false;
            }

            return true;
        }
    }
}