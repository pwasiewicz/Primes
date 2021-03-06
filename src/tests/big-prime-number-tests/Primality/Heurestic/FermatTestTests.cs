﻿using System.Numerics;
using System.Threading.Tasks;
using BigPrimeNumber.Primality.Heuristic;
using BigPrimeNumberTests.Tests;
using Xunit;

namespace BigPrimeNumberTests.Primality.Heurestic
{
    public class FermatTestTests : PrimalityTestBase
    {
        [Theory]
        [MemberData(nameof(PrimeNumbersArguments))]
        public async Task Test_SmallPrimes_ReturnsTrue(int prime)
        {
            var test = new FermatTest(10);
            var result = await test.TestAsync(new BigInteger(prime));

            Assert.True(result);
        }

        [Theory]
        [MemberData(nameof(GeneratedCompositeNumbers))]
        public async Task Test_BigComposite_ReturnsTrue(long composite)
        {
            var test = new FermatTest(15);
            var result = await test.TestAsync(new BigInteger(composite));

            Assert.False(result);
        }


        [Fact]
        public async Task Test_BigPrime_ReturnsTrue()
        {
            var test = new FermatTest(1000);
            var result = await test.TestAsync(BigKnownNumber());

            Assert.True(result);
        }
    }
}
