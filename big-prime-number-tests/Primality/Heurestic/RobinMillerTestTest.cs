using System.Numerics;
using System.Threading.Tasks;
using BigPrimeNumber.Primality.Heuristic;
using Xunit;

namespace BigPrimeNumberTests.Primality.Heurestic
{
    public class RobinMillerTestTest
    {
        [Fact]
        public async Task Test_Prime13_ReturnsTrue()
        {
            var test = new RobinMillerTest(3);
            var result = await test.TestAsync(new BigInteger(13));

            Assert.True(result);
        }
    }
}
