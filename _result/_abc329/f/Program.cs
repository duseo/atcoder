using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadInt();
        var q = io.ReadInt();
        var m = new Dictionary<int, HashSet<int>>();
        for (int i = 1; i <= n; i++)
        {
            var ci = io.ReadInt();
            if (!m.ContainsKey(i))
            {
                m.Add(i, new HashSet<int>()); 
            }

            m[i].Add(ci);
        }

        for (int i = 0; i < q; i++)
        {
            var u = io.ReadInt();
            var v = io.ReadInt();
            var from = m[v].Count < m[u].Count ? m[v] : m[u]; 
            var to = m[v].Count < m[u].Count ? m[u] : m[v];

            foreach (var item in from)
            {
                to.Add(item);
            }

            m[v] = to;
            m[u] = new();
            
            io.WriteLine(m[v].Count);
        }
    }
}