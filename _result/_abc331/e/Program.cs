using System.Security.Cryptography.X509Certificates;
using System.Text;
using Library;

class Oracle : IOracle<int>
{
    public int IdentityElement => int.MinValue;
    public int Operate(int a, int b)
    {
        return Math.Max(a, b);
    }
}

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadInt();
        var m = io.ReadInt();
        var l = io.ReadInt();

        var mains = io.ReadIntArray(n);
        var sides = io.ReadIntArray(m);
        var adj = new Dictionary<int, List<int>>();
        
        for (int i = 0; i < n; i++)
        {
           adj.Add(i,new()); 
        }

        for (int i = 0; i < l; i++)
        {
            var u = io.ReadInt()-1;
            var v = io.ReadInt()-1;
            
            adj[u].Add(v);
        }

        var st = new SegmentTree<int>(m, new Oracle());
        for (int i = 0; i < m; i++)
        {
           st.Set(i, sides[i]); 
        }

        var res = 0;
        for (int i = 0; i < n; i++)
        {
            foreach (var ma in adj[i])
            {
                st.Set(ma,int.MinValue);
            }

            res = Math.Max(res,st.QueryToAll() + mains[i]);
            
            foreach (var ma in adj[i])
            {
                st.Set(ma,sides[ma]);
            }
        }

        io.WriteLine(res);
    }
}
