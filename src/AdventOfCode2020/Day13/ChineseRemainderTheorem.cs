using System.Linq;
using System.Numerics;

namespace AdventOfCode2020.Day13
{
    /// <summary>
    /// adapted from https://rosettacode.org/wiki/Chinese_remainder_theorem#C.23
    /// updated to use BigInteger rather than int in several places
    /// </summary>
    public static class ChineseRemainderTheorem
    {
        public static BigInteger Solve(int[] n, int[] a)
        {
            BigInteger prod = n.Aggregate(new BigInteger(1), (i, j) => i * j);
            BigInteger p;
            BigInteger sm = 0;
            for (int i = 0; i < n.Length; i++)
            {
                p = prod / n[i];
                sm += a[i] * ModularMultiplicativeInverse(p, n[i]) * p;
            }
            return sm % prod;
        }

        private static int ModularMultiplicativeInverse(BigInteger a, int mod)
        {
            BigInteger b = a % mod;
            for (int x = 1; x < mod; x++)
            {
                if ((b * x) % mod == 1)
                {
                    return x;
                }
            }
            return 1;
        }
    }
}