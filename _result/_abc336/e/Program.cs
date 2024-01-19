using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadString();

        long ans = 0;

        for (int s = 1; s < 9*14; s++)
        {
            var dp = new long[n.Length+1, s+1, s, 2];
            dp[0, 0, 0, 1] = 1;

            for (int d = 0; d < n.Length; d++)
            {
                for (int i = 0; i < s+1; i++)
                {
                    for (int j = 0; j < s; j++)
                    {
                        for (int f = 0; f < 2; f++)
                        {
                            for (int t = 0; t < 10; t++)
                            {
                                if (i + t > s) continue;
                                if (f > 0 && n[d] - '0' < t) continue;
                                dp[d + 1, i + t, (j * 10 + t) % s, (f > 0 && n[d] - '0' == t) ? 1 : 0] +=
                                    dp[d, i, j, f];
                            }
                        }
                    }
                } 
            }

            ans += dp[n.Length, s, 0, 0] + dp[n.Length, s, 0, 1];
        }
        
        io.WriteLine(ans);
    }
}
