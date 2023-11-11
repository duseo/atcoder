using System.Runtime.InteropServices;

namespace Library;

public interface IEdge
{
    int To { get; }
}

public interface IWeightedEdge : IEdge
{
    long Weight { get; }
}

public interface IGraph<TEdge> where TEdge : IEdge
{
    ReadOnlySpan<TEdge> this[int node] { get; }
    int NodeCount { get; }
}

public interface IWeightedGraph<TEdge> : IGraph<TEdge> where TEdge : IWeightedEdge { }

public readonly struct BasicEdge : IEdge
{
    public int To { get; }

    public BasicEdge(int to)
    {
        To = to;
    }

    public override string ToString() => To.ToString();
    public static implicit operator BasicEdge(int edge) => new BasicEdge(edge);
    public static implicit operator int(BasicEdge edge) => edge.To;
}

[StructLayout(LayoutKind.Auto)]
public readonly struct WeightedEdge : IWeightedEdge
{
    public int To { get; }
    public long Weight { get; }

    public WeightedEdge(int to) : this(to, 1) { }

    public WeightedEdge(int to, long weight)
    {
        To = to;
        Weight = weight;
    }

    public override string ToString() => $"[{Weight}]-->{To}";
    public void Deconstruct(out int to, out long weight) => (to, weight) = (To, Weight);
}

public class BasicGraph : IGraph<BasicEdge>
{
    private readonly List<List<BasicEdge>> _edges;
    public List<List<BasicEdge>> Edges => _edges;
    public ReadOnlySpan<BasicEdge> this[int node] => _edges[node].AsSpan();
    public int NodeCount => _edges.Count;

    public BasicGraph(int nodeCount)
    {
        _edges = new List<List<BasicEdge>>(nodeCount);
        for (int i = 0; i < nodeCount; i++)
        {
            _edges.Add(new List<BasicEdge>());
        }
    }

    public void AddEdge(int from, int to) => _edges[from].Add(to);
    public void AddNode() => _edges.Add(new List<BasicEdge>());

    public bool IsBipartite()
    {
        var visited = new HashSet<int>();
        var colors = new int[NodeCount];

        var isBipartite = true;
#pragma warning disable CS8600
        Action<int, HashSet<int>, int[]> Dfs = null;
#pragma warning restore CS8600
        Dfs = delegate(int current, HashSet<int> visited, int[] color)
        {
            if (!visited.Contains(current))
            {
                visited.Add(current);
                if (color[current] == 0)
                {
                    color[current] = 1;
                }
                foreach (var edge in _edges[current])
                {
                    if (color[edge.To] == color[current])
                    {
                        isBipartite = false;
                        return;
                    }
                    else
                    {
                        color[edge.To] = color[current] == 1 ? 2 : 1;
                    }

                    if (Dfs is not null)
                    {
                        Dfs(edge.To, visited, colors);
                    }
                }
            } 
        };
        
        for (int i = 0; i < NodeCount; i++)
        {
            if (!visited.Contains(i))
            {
                Dfs(i, visited, colors);
            } 
        } 
        
        return isBipartite;
    }
}

public class WeightedGraph : IGraph<WeightedEdge>
{
    private readonly List<List<WeightedEdge>> _edges;
    public ReadOnlySpan<WeightedEdge> this[int node] => _edges[node].AsSpan();
    public int NodeCount => _edges.Count;

    public WeightedGraph(int nodeCount)
    {
        _edges = new List<List<WeightedEdge>>(nodeCount);
        for (int i = 0; i < nodeCount; i++)
        {
            _edges.Add(new List<WeightedEdge>());
        }
    }

    public void AddEdge(int from, int to, long weight) => _edges[from].Add(new WeightedEdge(to, weight));
    public void AddNode() => _edges.Add(new List<WeightedEdge>());
}
