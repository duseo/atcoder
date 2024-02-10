using System.Numerics;
using Library;

class AtCoder
{
    private static Dictionary<long, BigInteger> dp = new Dictionary<long, BigInteger>();

    public static void Main()
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadLong();
        Console.WriteLine(CalculateCost(n));
    }

    private static BigInteger CalculateCost(long n)
    {
        if (n <= 1) return 0;
        if (dp.ContainsKey(n)) return dp[n];
        
        long half = n / 2;
        long nextPowerOfTwo = 1;
        while (nextPowerOfTwo <= n) nextPowerOfTwo *= 2;
        nextPowerOfTwo /= 2;
        
        BigInteger cost = n + CalculateCost(half) + CalculateCost(n - half);
        dp[n] = cost;
        
        return cost;
    }
}
