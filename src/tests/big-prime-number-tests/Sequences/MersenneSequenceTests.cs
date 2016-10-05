using System.Collections.Generic;
using System.Threading.Tasks;
using BigPrimeNumber.Sequences;
using Xunit;

namespace BigPrimeNumberTests.Sequences
{
    public class MersenneSequenceTests 
    {
        [Theory]
        [MemberData(nameof(MerseneNumbers))]
        public void Value_AtPositions_ReturnsValue(int n, int expectedValue)
        {
            var v = MersenneSequence.Value(n);

            Assert.Equal(expectedValue, v);
        }

        [Theory]
        [MemberData(nameof(PrimeMerseneNumbers))]
        public async Task IsPrime_AtPositions_ReturnsTrue(int n, int expectedValue)
        {
            var result = await MersenneSequence.IsPrimeAsync(n);

            Assert.True(result);
        }

        public static IEnumerable<object[]> MerseneNumbers => new[]
{
            new object[] {7, 127},
            new object[] {11, 2047},
            new object[] {23, 8388607},
        };

        public static IEnumerable<object[]> PrimeMerseneNumbers => new[]
        {
            new object[] {7, 127},
            new object[] {17, 131071}
        };
    }
}
