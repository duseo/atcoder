using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadInt();
        var ql = io.ReadIntArray(n);
        var al = io.ReadIntArray(n);
        var bl = io.ReadIntArray(n);

        bool IsFeasible(long mid)
        {
            bool ok = false;
            for (long a = 0; a <= mid; a++)
            {
                var b = mid - a;
                ok = true;
                for (long j = 0; j < n; j++)
                {
                    if (a * al[j] + b * bl[j] > ql[j])
                    {
                        ok = false;
                        break;
                    }
                }

                if (ok)
                {
                    break;
                }
            }
            return ok;
        }

        var lo = 0L;
        var hi = (long)(ql.Max() * n);
        while (lo < hi)
        {
            long mid = lo + (hi - lo + 1) / 2;

            if (IsFeasible(mid))
            {
                lo = mid;
            }
            else
            {
                hi = mid-1;
            }
        }
        
        io.WriteLine(lo);

    }
}
