using System.Numerics;
using System.Threading.Tasks;
using BigPrimeNumber.Primality.Deterministic;
using BigPrimeNumberTests.Tests;
using Xunit;

namespace BigPrimeNumberTests.Primality.Deterministic
{
    public class NaiveTestTest : PrimalityTestBase
    {
        [Theory]
        [MemberData(nameof(PrimeNumbersArguments))]
        public async Task Test_SmallPrimes_ReturnsTrue(int prime)
        {
            var test = new NaiveTest();
            var result = await test.TestAsync(new BigInteger(prime));

            Assert.True(result);
        }
    }
}
