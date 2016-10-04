using System.Numerics;
using System.Threading.Tasks;
using BigPrimeNumber.Primality.Heuristic;
using BigPrimeNumberTests.Tests;
using Xunit;

namespace BigPrimeNumberTests.Primality.Heurestic
{
    public class RobinMillerTestTests : PrimalityTestBase
    {
        [Theory]
        [MemberData(nameof(PrimeNumbersArguments))]
        public async Task Test_SmallPrime_ReturnsTrue(int prime)
        {
            var test = new RobinMillerTest(15);
            var result = await test.TestAsync(new BigInteger(prime));

            Assert.True(result);
        }

        [Theory]
        [MemberData(nameof(GeneratedCompositeNumbers))]
        public async Task Test_BigComposite_ReturnsTrue(long composite)
        {
            var test = new RobinMillerTest(15);
            var result = await test.TestAsync(new BigInteger(composite));

            Assert.False(result);
        }

        [Fact]
        public async Task Test_BigPrime_ReturnsTrue()
        {
            var test = new RobinMillerTest(1000);
            var result = await test.TestAsync(BigKnownNumber());

            Assert.True(result);
        }
    }
}
