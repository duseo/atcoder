using System.IO.Pipes;
using System.Text;
using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var a = io.ReadString();
        var b = io.ReadString();

        var dp = new int[a.Length + 1, b.Length + 1];
        var from = new string[a.Length + 1, b.Length + 1];
        dp[0, 0] = 0;

        for (int i = 0; i < a.Length; i++)
        {
            for (int j = 0; j < b.Length; j++)
            {
                var choose = 0;
                if (a[i] == b[j])
                {
                    choose = dp[i, j] + 1;
                }
                
                dp[i+1,j+1] = Math.Max(choose, Math.Max(dp[i+1,j],dp[i,j+1]));
                if (dp[i + 1, j + 1] == choose && choose != 0)
                {
                    from[i + 1, j + 1] = "D";
                }
                else if (dp[i + 1, j + 1] == dp[i + 1, j])
                {
                    from[i + 1, j + 1] = "UP";
                }
                else
                {
                    from[i + 1, j + 1] = "LEFT";
                }

            } 
        }

        var x = a.Length;
        var y = b.Length;
        var res = new StringBuilder();
        while (x > 0 && y > 0)
        {
            if (from[x,y] == "D")
            {
                res.Insert(0, a[x-1]);
                x--;
                y--;
            }
            else if (from[x,y] == "LEFT")
            {
                x--;
            }
            else
            {
                y--;
            }
        }

        io.WriteLine(res.ToString());
        io.Flush();
    }
}
