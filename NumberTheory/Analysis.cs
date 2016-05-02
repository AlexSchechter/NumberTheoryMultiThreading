using System.Collections.Generic;
using static System.Math;

namespace NumberTheory
{
    public class Analysis
    {
        private List<ulong> fPrimeFactors;

        public bool isPrime(ulong number)
        {
            for (ulong i = 2; i <= Floor(Sqrt(number)); i++)
            {
                return !(number % i == 0);
            }

            return true; 
        }

        public ulong CalculateLargestPrime(ulong number)
        {
            for (ulong i = number; i > 2; i--)
            {
                if (isPrime(i))
                {
                    return i;
                }
            }

            return 2;
        }
        public List<ulong> CalculatePrimeFactors(ulong number)
        {
            fPrimeFactors = new List<ulong>();
            ulong rest = number;
            ulong nextPrimeFactor = 0;

            do
            {
                nextPrimeFactor = CalculateSmallestPrimeFactor(rest);
                fPrimeFactors.Add(nextPrimeFactor);
                rest /= nextPrimeFactor;
            } while (rest != 1);

            return fPrimeFactors;
        }

        private ulong CalculateSmallestPrimeFactor(ulong number)
        {
            for (ulong i = 2; i <= Floor(Sqrt(number)); i++)
            {
                if (number % i == 0)
                {
                    return i;
                }
            }

            return number;
        }
    }
}
