using Library;

class AtCoder
{
    static int Min(int a, int b, int c) => Math.Min(a, Math.Min(b, c));

    
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        
        (int a, int b, int x) GN()
        {
            var input = io.ReadIntArray(3);
            return (input[0], input[1], input[2]);
        }

        var n = io.ReadInt();
        
        var g = new WeightedGraph(n+5);

        for (int i = 1; i < n; i++)
        {
            var(a,b, x) = GN();
            g.AddEdge(i,i+1, a);
            g.AddEdge(i,x, b);
        }

        var dp = g.Dijkstra(1);
        io.WriteLine(dp[n]);
        

    }
}
