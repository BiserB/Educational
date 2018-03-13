namespace CallStack
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static bool IsPrime(int num)
        {
            var maxDivider = Math.Sqrt(num);
            for (int divider = 2; divider <= maxDivider; divider++)
            {
                if (num % divider == 0)
                {
                    return false;
                }
            }

            return true;
        }

        static List<int> PrimesInRange(int start, int end)
        {
            var primes = new List<int>();
            for (int primeCandidate = start; primeCandidate <= end; primeCandidate++)
            {
                if (IsPrime(primeCandidate))
                {
                    primes.Add(primeCandidate);
                }
            }

            return primes;
        }

        static void Main()
        {
            var start = int.Parse(Console.ReadLine());
            var end = int.Parse(Console.ReadLine());

            var primes = PrimesInRange(start, end);

            Console.WriteLine(string.Join(" ", primes));
        }
    }
}
