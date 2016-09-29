using System.Numerics;
using System.Threading.Tasks;

namespace BigPrimeNumber.Primality
{
    public interface IPrimalityTest
    {
        Task<bool> TestAsync(BigInteger source);
    }
}
