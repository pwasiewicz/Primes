# big-prime-number
Useful collection of tools for .NET Core that handlies prime numbers. Very big prime numbers (BigInteger).

## Api / Docs

### Testing primality

```x@
var someBigNBumber = new BigInteger("2391030138092183021830123");
var isPrime = await someBigNumber.IsPrimeAsync(new RobinMillerTest(complexity: 50))
```

Available test algorithms:
- Miller–Rabin test
- Fermat test
- Solovay-Strassen test
- Naive test

#### Implementing own test

You can create own test. All you need is to implement interface:

```c#
public interface IPrimalityTest
{
    Task<bool> TestAsync(BigInteger source);
}
```

You can also use helper class:

```c#
public abstract class PrimalityTest: IPrimalityTest
{
}
```

It has bunch of methods that can be useful for testing.

#### Generating primes

*PrimaryBigInteger* class contains some methods like generating prime numbers:

```c#
public static Task<BigInteger> GeneratePrime(uint bitLength, IRandomProvider randomProvider, IPrimalityTest primalityTest)
public static Task<BigInteger> GenerateProbablyPrime(uint bitLength)
```

### Mersenne sequence

*MersenneSequence* is a class, that contains bunch of methods for handling that sequence:

```c#
public static BigInteger Value(int n)
``` 
*Generates a value of n-th mersenne number*

```c#
public static IEnumerable<BigInteger> Generate(int count = int.MaxValue)
``` 
*Generates an enumerable that contains a specified count of mersenne numbers*

```c#
public static Task<bool> IsPrimeAsync(int n)
``` 
*Checkes wheter n-th mersenne number is prime or not*
