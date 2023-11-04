using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadInt();
        var m = io.ReadInt();
        var a = io.ReadIntArray(m);
        var b = io.ReadIntArray(m);
        var edges = a.Zip(b);
        var graph = new BasicGraph(n);
        foreach (var edge in edges)
        {
           graph.AddEdge(edge.First-1, edge.Second-1); 
           graph.AddEdge(edge.Second-1, edge.First-1); 
        }
        io.WriteBool(graph.IsBipartite());
    }
}


