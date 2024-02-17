using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadInt();
        var a = io.ReadIntArray(n).Select(x => (long)x).ToList();
        for (int i = 1; i < n; i++)
        {
            var s = io.ReadLong();
            var t = io.ReadLong();
            if (a[i-1] >= s)
            {
                var mult =  a[i - 1] / s;
                a[i] += mult * t;
            }
        }
        io.WriteLine(a[n-1]);
    }
}

