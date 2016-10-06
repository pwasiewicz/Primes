using System.Collections.Generic;
using System.Threading.Tasks;
using BigPrimeNumber.Tools;
using Xunit;

namespace BigPrimeNumberTests.Tools
{
    public class CoprimeBigIntegerTests
    {
        [Theory]
        [MemberData(nameof(GetKnownCoprimeIntegers))]
        public async Task AreCoprimeAsync_Cooprimes_RetunrsTrue(int x, int y)
        {
            var result = await CoprimeBigInteger.AreCoprimeAsync(x, y);
            Assert.True(result);
        }

        [Theory]

        [MemberData(nameof(GetKnownTotientValues))]
        public async Task EulerTotientAsync_ValidValues(int x, int y)
        {
            var result = await CoprimeBigInteger.EulerTotientAsync(x);
            Assert.Equal(y, result);
        }

        public static IEnumerable<object[]> GetKnownCoprimeIntegers => new[]
{
            new object[] { 6, 35},
            new object[] { 15, 17},
            new object[] { 20, 21},
        };

        public static IEnumerable<object[]> GetKnownTotientValues  => new[]
        {
            new object[] { 2, 1},
            new object[] { 60, 16},
            new object[] { 99, 60},
        };
    }
}
