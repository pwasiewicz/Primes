using System.Collections.Generic;
using System.Threading.Tasks;
using BigPrimeNumber.Primality.Heuristic;
using BigPrimeNumber.Sequences;
using Xunit;

namespace BigPrimeNumberTests.Sequences
{
    public class MersenneSequenceTests 
    {
        [Theory]
        [MemberData(nameof(MerseneNumbers))]
        public void Value_AtPositions_ReturnsValieValue(int n, int expectedValue)
        {
            var v = MersenneSequence.Value(n);

            Assert.Equal(expectedValue, v);
        }

        public static IEnumerable<object[]> MerseneNumbers => new[]
        {
            new object[] {11, 2047},
            new object[] {23, 8388607},
        };
    }
}
