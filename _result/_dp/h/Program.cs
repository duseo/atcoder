using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var mod = new ModularArithmetic(1_000_000_007);
        var n = io.ReadInt();
        var m = io.ReadInt();

        var grid = new string[n];
        for (int i = 0; i < n; i++)
        {
            grid[i] = io.ReadString();
        }
        
        var dp = new int[n+1 ,m+1];
        dp[0, 0] = 1;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (grid[i][j] == '#')
                {
                    dp[i, j] = 0;
                }
                mod.Add(ref dp[i + 1, j], dp[i, j]);
                mod.Add(ref dp[i, j + 1] , dp[i, j]);
            }
        }
        
        io.WriteLine(dp[n-1,m-1]);
    }
}
