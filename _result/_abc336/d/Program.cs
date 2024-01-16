using System.IO.IsolatedStorage;
using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadInt();
        var a = new int[n + 2];

        for (int i = 1; i <= n; i++)
        {
            a[i] = io.ReadInt();
        }

        n+=2;

        var l = new int[n];
        for (int i = 1; i < n-1; i++)
        {
            l[i] = Math.Min(a[i], l[i-1]+1);
        }
        
        var r = new int[n];
        for (int i = n-1; i > 0; i--)
        {
           r[i-1] = Math.Min(a[i-1], r[i]+1);
        }

        var res = 0;
        for (int i = 0; i < n; i++)
        {
            var tmp = Math.Min(l[i], r[i]);
            res = Math.Max(res, tmp);
        }
        io.WriteLine(res);



    }
}
