using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadInt();
        var a = io.ReadIntArray(n);

        var m = new Dictionary<int, int>();

        for (int i = 1; i <= n; i++)
        {
            if (a[i-1] == -1)
            {
                m[0] = i;
                continue;
            }

            m[a[i-1]] = i;
        }

        var res = new int[n];
        var cur = 0;
        for (int i = 0; i < n; i++)
        {
            res[i] = m[cur];
            cur = m[cur];
        }
        io.WriteLine(res.ToList().Join(' '));

    }
}
