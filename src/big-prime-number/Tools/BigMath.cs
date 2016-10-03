using System;
using System.Numerics;

namespace BigPrimeNumber.Tools
{
    public static class BigMath
    {
        public static BigInteger SquareRoot(BigInteger value)
        {
            if (value.Sign < 0) throw new ArgumentOutOfRangeException(nameof(value), "Number must be positive.");
            if (value == BigInteger.Zero)
                throw new ArgumentException("Cannot calculate square root from 0.", nameof(value));       

            if (value == BigInteger.One) return BigInteger.One;

            
            BigInteger start = BigInteger.One, end = value, ans = BigInteger.Zero;

            while (start <= end)
            {
                var mid = BigInteger.Divide(BigInteger.Add(start, end), 2);

                var powed = BigInteger.Pow(mid, 2);
                if (powed == value)
                    return mid;

                if (powed < value)
                {
                    start = BigInteger.Add(mid, 1);
                    ans = mid;
                }
                else
                {
                    end = BigInteger.Subtract(mid, 1);
                }
            }
            return ans;
        }
    }
}
