using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace BigPrimeNumber.Sequences
{
    public static class MersenneSequence
    {
        public static BigInteger Value(int n)
        {
            return -1*(1 - BigInteger.Pow(2, n));
        }

        public static IEnumerable<BigInteger> Generate(int count = int.MaxValue)
        {
            var i = 0;

            while (i < count)
            {
                var result = Value(i);
                i++;

                yield return result;
            }            
        }

        public static Task<bool> IsPrimeAsync(int n)
        {
            var mersenneValue = Value(n);

            return Task.Run(() => LucasLehmerCore(n, mersenneValue)).ContinueWith(t => t.Result == BigInteger.Zero);
        }

        private static BigInteger LucasLehmerCore(int n, BigInteger merseneValue)
        {
            var s = new BigInteger(4);

            for (var i = 1; i < n - 1; i++)
                s = (BigInteger.Pow(s, 2) - 2) % merseneValue;

            return s;
        }
    }
}

