using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        //agc43a
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var h = io.ReadInt();
        var w = io.ReadInt();
        var grid = new string[h];
        for (int i = 0; i < h; i++)
        {
            grid[i] = $"{(i==0?".":"X")}{io.ReadString()}";
        }

        var dp = new int[h, w+1];

        for (int i = 0; i < w; i++)
        {
            dp[0, i + 1] = dp[0, i];
            if (grid[0][i] == '.' && grid[0][i+1] == '#')
            {
                dp[0, i + 1]++;
            } 
        }


        for (int i = 0; i < h-1; i++)
        {
            dp[i + 1, 1] = dp[i, 1];
            if (grid[i][1] == '.' && grid[i+1][1] == '#')
            {
                dp[i + 1, 1]++;
            }
        }

        for (int i = 1; i < h; i++)
        {
            for (int j = 2; j < w+1; j++)
            {
                if (grid[i][j] == '.')
                {
                    dp[i, j] = Math.Min(dp[i - 1, j], dp[i, j - 1]);
                }

                if (grid[i][j] == '#')
                {
                    dp[i, j] = Math.Min(
                        dp[i - 1, j] + (grid[i - 1][j] == '.' ? 1 : 0),
                        dp[i, j - 1] + (grid[i][j - 1] == '.' ? 1 : 0));
                }
            }
        }

        io.WriteLine(dp[h-1,w]);
    }
}
