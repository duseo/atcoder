using Library;

class AtCoder
{
    public static long Max(long a, long b, long c)
    {
        return Math.Max(a, Math.Max(b, c));
    }
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadInt();
        var k = io.ReadInt();
        
        var dp = new long[n, k+1];

        for (int i = 0; i < n; i++)
        {
            var u = io.ReadLong();
            var w = io.ReadLong();
            for (int j = 1; j <= k; j++)
            {
                if (i == 0)
                {
                    dp[i, j] = j - u < 0 ? 0 : w;
                }
                else
                {
                    dp[i, j] = Math.Max(
                        dp[i-1,j],
                        (i < 1 || j-u < 0 ? 0 : dp[i-1,j-u] + w));
                }
                
            }
        }
        
        io.WriteLine(dp[n-1, k]);
    }
}
