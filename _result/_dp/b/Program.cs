using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadInt();
        var k = io.ReadInt();
        var ab = io.ReadIntArray(n);
        
        var dp = new int[n];
        for (int i = 1; i < n; i++)
        {
            dp[i] = int.MaxValue;
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 1; j <= k; j++)
            {
                if (i + j < n)
                {
                    dp[i + j] = Math.Min(dp[i + j], dp[i] + Math.Abs(ab[i] - ab[i + j]));
                }
            }            
        }
        
        io.WriteLine(dp[n-1]);
    }
}
