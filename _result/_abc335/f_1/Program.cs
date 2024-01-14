using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadInt();
        var a = io.ReadIntArray(n);

        var ma = new ModularArithmetic(998244353);

        var d = 400;

        var dp = new int[n];
        dp[0] = 1;
        var s = new int[d, n];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < d; j++)
            {
                dp[i] = ma.Add(dp[i], s[j, i]);
                if (i+j<n)
                {
                    s[j, i + j]=ma.Add(s[j, i + j], s[j, i]);
                }
            }

            if (a[i] < d)
            {
                if (i+a[i] < n)
                {
                    s[a[i], i + a[i]] = ma.Add(s[a[i],i+a[i]], dp[i]);
                } 
            }
            else
            {
                for (int j = i + a[i]; j < n; j+=a[i])
                {
                    dp[j] = ma.Add(dp[j], dp[i]);
                }
            }
        }

        var res = 0;
        foreach (var x in dp)
        {
            res = ma.Add(res, x);
        }
        io.WriteLine(res);

    }
}
