using Library;

class Oracle : IOracle<int>
{
    public int IdentityElement => 1 << 30;

    public int Operate(int a, int b)
    {
        return Math.Min(a, b);
    }
}

class AtCoder
{
    static void Main(string[] args)
    {
        const int Inf = 1 << 30;
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadInt();
        var q = io.ReadInt();

        var list = io.ReadIntArray(n);
        var cnt = new int[n+1];
        var st = new SegmentTree<int>(n + 1, new Oracle());

        for (int i = 0; i <= n; i++)
        {
           st.Set(i,i); 
        }

        foreach (var x in list)
        {
            if (x <= n)
            {
               st.Set(x, Inf);
               cnt[x]++;
            }
        }

        for (int i = 0; i < q; i++)
        {
            var ind = io.ReadInt() - 1;
            var val = io.ReadInt();
            var prev = list[ind];
            list[ind] = val;

            if (prev <= n)
            {
                cnt[prev]--;
                if (cnt[prev] <= 0)
                {
                    st.Set(prev, prev);
                }
            }

            if (val <= n)
            {
                cnt[val]++;
                st.Set(val, Inf);
            }

            var mex = Math.Min(st.QueryToAll(), n);
            io.WriteLine(mex);
        }
    }
}
