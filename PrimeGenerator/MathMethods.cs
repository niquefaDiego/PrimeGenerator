using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeGenerator
{
    public static class MathMethods
    {
        public static bool IsPrime(int n) {
            for (int d = 2; d * d <= n; ++d)
                if (n % d == 0)
                    return false;
            return true;
        }

        public static bool IsPalindrome(int n) {
            return ReverseDigits(n) == n;
        }

        /// <summary>
        /// See https://en.wikipedia.org/wiki/Circular_prime
        /// </summary>
        /// <param name="n">n must be a prime</param>
        /// <returns>True if every circular rotation of n is a prime.</returns>
        public static bool IsCircularPrime(int n)
        {
            int p10 = 1;
            while (p10 * 10 <= n) p10 *= 10;
            int x = n % 10 * p10 + n / 10;
            while(x != n) {
                if (!IsPrime(x)) return false;
                x = x % 10 * p10 + x / 10;
            }
            return true;
        }
        /// <summary>
        /// See https://en.wikipedia.org/wiki/Truncatable_prime
        /// </summary>
        /// <param name="n">n must be a prime</param>
        /// <returns>True if every preffix of n is a prime.</returns>

        public static bool IsRightTruncatable(int n) {
            while ( n > 9 ) {
                n /= 10;
                if (!IsPrime(n)) return false;
            }
            return true; 
        }

        public static int ReverseDigits(int n)
        {
            int rn = 0;
            while (n > 0)
            {
                rn = rn * 10 + n % 10;
                n /= 10;
            }
            return rn;
        }
    }
}
