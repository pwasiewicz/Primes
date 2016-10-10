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
