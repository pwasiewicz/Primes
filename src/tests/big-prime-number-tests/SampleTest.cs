using System;
using System.Threading.Tasks;
using BigPrimeNumber.Tools;
using Xunit;

namespace BigPrimeNumberTests
{
    public class SampleTest
    {
        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, 2+2);
        }

        [Fact]
        public async Task GeneratingPrime()
        {
            var pri = await PrimaryBigInteger.GenerateProbablyPrime(2048);

            Console.Out.WriteLine(pri.ToString());
        }
    }
}
