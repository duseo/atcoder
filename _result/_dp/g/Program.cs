using System.Net;
using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadInt();
        var m = io.ReadInt();
        var g = new BasicGraph(n);
        for (int i = 0; i < m; i++)
        {
            var from = io.ReadInt()-1;
            var to = io.ReadInt()-1;
            g.AddEdge(from, to);
        }

        var dp = new int[n];
        dp.Fill(-1);
        
        Func<int, int> Rec = null;
        Rec = delegate(int node)
        {
            if (dp[node] != -1)
            {
                return dp[node];
            }

            var res = 0;
            foreach (var to in g.Edges[node])
            {
                res = Math.Max(res, Rec(to.To) + 1);
            }

            dp[node] = res;
            return res;
        };

        var res = 0;
        for (int i = 0; i < n; i++)
        {
            res = Math.Max(res, Rec(i));
        }
        io.WriteLine(res);

    }
}
