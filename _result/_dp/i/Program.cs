using System.Globalization;
using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadInt();
        var dp = new double[n + 1, n + 1];
        dp[0, 0] = 1;
        for (int i = 0; i < n; i++)
        {
            var p = io.ReadDouble();
            for (int j = 0; j < n; j++)
            {
                dp[i + 1, j + 1] += dp[i, j] * p;
                dp[i + 1, j] += dp[i, j] * (1 - p);
            }
        }

        var res = 0d;
        for (int i = (n/2)+1; i <= n; i++)
        {
            res += dp[n, i];
        } 
        
        Console.WriteLine(res);
    }
}
