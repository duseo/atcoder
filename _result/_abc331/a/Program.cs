using System.Runtime.InteropServices;
using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var mo = io.ReadInt();
        var da = io.ReadInt();
        var y = io.ReadInt();
        var m = io.ReadInt();
        var d = io.ReadInt();

        if (d == da && m == mo)
        {
            io.WriteLine($"{y+1} {1} {1}");
            return;
        }
        
        if (d == da)
        {
            io.WriteLine($"{y} {m+1} {1}");
            return;
        }
        
        io.WriteLine($"{y} {m} {d+1}");
    }
}
