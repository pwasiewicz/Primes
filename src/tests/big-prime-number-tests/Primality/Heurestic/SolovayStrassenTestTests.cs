using System.Numerics;
using System.Threading.Tasks;
using BigPrimeNumber.Primality.Heuristic;
using BigPrimeNumberTests.Tests;
using Xunit;

namespace BigPrimeNumberTests.Primality.Heurestic
{
    public class SolovayStrassenTestTests : PrimalityTestBase
    {
        [Fact]
        public async Task Test_Prime_ReturnsTrue()
        {
            var test = new SolovayStrassenTest(10);
            var result = await test.TestAsync(new BigInteger(13));

            Assert.True(result);
        }

        [Fact]
        public async Task Test_BigPrime_ReturnsTrue()
        {
            var test = new SolovayStrassenTest(1000);
            var result = await test.TestAsync(BigKnownNumber());

            Assert.True(result);
        }
    }
}
