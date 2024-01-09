using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadInt();
        var m = io.ReadInt();
        var pq = new PriorityQueue<(int v, int ai)>((l, r) => l.ai.CompareTo(r.ai));
        var graph = new BasicGraph(n);
        var a = io.ReadIntArray(n);
        for (int i = 0; i < m; i++)
        {
            var u = io.ReadInt()-1;
            var v = io.ReadInt()-1;
            graph.AddEdge(u,v);
            graph.AddEdge(v,u);
        }

        var ans = new int[n];
        ans[0] = 1;
        
        pq.Enqueue((0,a[0]));
        while (pq.Count > 0)
        {
            (var cur, var ai) = pq.Dequeue();
            foreach (var to in graph.Edges[cur])
            {
                var t = to.To;
                if (a[to.To] < ai) continue;
                var na = ans[cur] + (a[to.To] == ai ? 0 : 1);
                if (ans[to] >= na) continue;
                ans[to] = na;
                pq.Enqueue((to, a[to]));
            }
        }
        
        io.WriteLine(ans[n-1]);
    }
}
