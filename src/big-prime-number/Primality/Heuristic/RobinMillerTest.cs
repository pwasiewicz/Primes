using System;
using System.Numerics;
using System.Threading.Tasks;
using BigPrimeNumber.Helpers;

namespace BigPrimeNumber.Primality.Heuristic
{
    public class RobinMillerTest : IPrimalityTest
    {
        private readonly uint complexity;

        public RobinMillerTest(uint complexity)
        {
            this.complexity = complexity;
        }

        public async Task<bool> TestAsync(BigInteger source)
        {
            var trivialCheck = await BigIntegerHelpers.TrivialCheckAsync(source);
            if (trivialCheck.HasValue) return trivialCheck.Value;

            var paramateres = await CalculateParameterAsync(source);
            var d = paramateres.Item1;
            var s = paramateres.Item2;

            var sourceMinusOne = BigInteger.Subtract(source, BigIntegerHelpers.One);
            var maxRangeToGetFrom = BigInteger.Subtract(source, BigIntegerHelpers.Two);

            var isPrime = true;

            for (var i = 0; i < this.complexity; i++)
            {
                var a = await BigIntegerHelpers.RandomIntegerBelowAsync(maxRangeToGetFrom);
                var x = BigInteger.ModPow(a, d, source);
                if (x.Equals(BigIntegerHelpers.One) || x.Equals(sourceMinusOne)) continue;

                var j = BigIntegerHelpers.One;

                await Task.Run(() =>
                {
                    while (j < s && !x.Equals(sourceMinusOne))
                    {
                        x = BigInteger.ModPow(x, BigIntegerHelpers.Two, source);
                        if (x.Equals(BigIntegerHelpers.One))
                        {
                            isPrime = false;
                            break;
                        }

                        j = BigInteger.Add(j, BigIntegerHelpers.One);
                    }
                });
                
                if (!isPrime) break;

                if (x.Equals(sourceMinusOne)) continue;

                isPrime = false;
                break;
            }

            return isPrime;
        }

        private static async Task<Tuple<BigInteger, BigInteger>> CalculateParameterAsync(BigInteger source)
        {
            var d = BigInteger.Subtract(source, BigIntegerHelpers.One);
            var s = BigIntegerHelpers.Zero;

            await Task.Run(() =>
            {
                while (BigInteger.Remainder(d, BigIntegerHelpers.Two).Equals(BigIntegerHelpers.Zero))
                {
                    s = BigInteger.Add(s, BigIntegerHelpers.One);
                    d = BigInteger.Divide(d, BigIntegerHelpers.Two);
                }
            });

            return new Tuple<BigInteger, BigInteger>(d, s);
        }
    }
}
