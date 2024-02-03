using System.IO.IsolatedStorage;
using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadInt();
        var a = io.ReadIntArray(n).Select(x=> (long)x).Prepend(0).ToList();
        var min = 0L;
        for (int i = 1; i <= n; i++)
        {
            a[i] += a[i - 1];
            min = Math.Min(min, a[i]);
        }
        io.WriteLine(a.Last()-min);
         
    }
}