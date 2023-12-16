using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadInt();
        var g = new BasicGraph(n);
        for (int i = 0; i < n-1; i++)
        {
            var u = io.ReadInt()-1;
            var v = io.ReadInt()-1;
            g.AddEdge(u,v);
            g.AddEdge(v,u);
        }

        if (g.Edges[0].Count == 1)
        {
           io.WriteLine(1);
           return;
        }

        var res = 0;
        foreach (var edge in g.Edges[0])
        {
            res = Math.Max(res, g.TreeSize(edge.To));
        }
        io.WriteLine(g.TreeSize(0) - res);

    }
}
