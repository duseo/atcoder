using System.Drawing;
using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var s = io.ReadLong();
        io.WriteLine((s >= 0 ? s+9 : s)/10);
    }
}
