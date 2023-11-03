using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadInt();

        var dp = new int[n, 3];
        dp[0, 0] = io.ReadInt();
        dp[0, 1] = io.ReadInt();
        dp[0, 2] = io.ReadInt();
        
        for (int i = 0; i < n-1; i++)
        {
            var cur = io.ReadIntArray(3);
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    if (j != k)
                    {
                        
                        dp[i + 1, k] = Math.Max(
                            dp[i + 1, k],
                            dp[i, j] + cur[k]);
                    }
                } 
            }
        }

        var res = 0;
        for (int i = 0; i < 3; i++)
        {
            res = Math.Max(res, dp[n - 1, i]);
        }
        io.WriteLine(res);
    }
}
