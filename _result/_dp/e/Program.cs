using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadInt();
        var k = io.ReadInt();

        var v = new int[n + 1];
        var w = new int[n + 1];

        var m = 0;
        for (int i = 1; i <= n; i++)
        {
            w[i] = io.ReadInt();
            v[i] = io.ReadInt();
            m += v[i];
        }

        var dp = new int[n + 1, m + 1];
        dp.Fill(int.MaxValue);
        dp[0,0] = 0;

        for (int i = 1; i <= n; i++)
        {
            for (int j = 0; j <= m; j++)
            {
                dp[i, j] = dp[i - 1, j];
                if (j - v[i] >= 0)
                {
                    var choose = dp[i - 1, j - v[i]] + w[i] < 0 ? int.MaxValue : dp[i - 1, j - v[i]] + w[i];
                    dp[i, j] = Math.Min(choose, dp[i - 1, j]);
                }
            } 
        }

        for (int i = m; i >= 0; i--)
        {
            if (dp[n,i] <= k)
            {
               io.WriteLine(i);
               return;
            } 
        }
    }
}
