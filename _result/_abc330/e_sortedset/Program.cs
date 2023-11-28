using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadInt();
        var q = io.ReadInt();

        var list = io.ReadIntArray(n);
        var cnt = new int[n+1];
        var st = new SortedSet<int>();

        for (int i = 0; i <= n; i++)
        {
            st.Add(i); 
        }

        foreach (var x in list)
        {
            if (x <= n)
            {
                st.Remove(x);
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
                    st.Add(prev);
                }
            }

            if (val <= n)
            {
                cnt[val]++;
                st.Remove(val);
            }

            var mex = Math.Min(st.First(), n);
            io.WriteLine(mex);
        }
    }
    }

