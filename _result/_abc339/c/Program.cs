using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadInt();
        var a = io.ReadIntArray(n).Prepend(0).Select(x => (long)x).ToList();

        var min = 0L;
        for (int i = 1; i <=n; i++)
        {
            a[i] += a[i - 1];
            if (a[i] < min)
            {
                min = a[i];
            }
        }

        a.RemoveAt(0);


        for (int i = 0; i < n; i++)
        {
            a[i] -= min;
        }
        
        io.WriteLine(a.Last());
        

    }
}
