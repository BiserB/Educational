using System;
using System.Numerics;

public class Program
{
    static void Main()
    {
        BigInteger n = int.Parse(Console.ReadLine());
        BigInteger k = int.Parse(Console.ReadLine());

       BigInteger result = CalcCoeficient(n, k);
        
        Console.WriteLine(result);
    }

    private static BigInteger CalcCoeficient(BigInteger n, BigInteger k)
    {
        BigInteger nFact = Factoriel(n);
        BigInteger n_kFact = Factoriel(n - k);
        BigInteger kFact = Factoriel(k);

        return nFact / (n_kFact * kFact); 
    }

    private static BigInteger Factoriel(BigInteger n)
    {
        if (n <= 1)
        {
            return 1;
        }
        BigInteger result = n * Factoriel(n - 1);
        return result;
    }

    //private static decimal CalcCoeficient(int n, int k)
    //{
    //    if (k > n)
    //    {
    //        return 0;
    //    }
    //    if (k == 0 || k == n)
    //    {
    //        return 1;
    //    }

    //    return CalcCoeficient(n - 1, k - 1) + CalcCoeficient(n - 1, k);
    //}
}
