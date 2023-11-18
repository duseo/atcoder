using System.Runtime.InteropServices;
using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var s = new SortedSet<int>();
        var n = io.ReadInt();
        for (int i = 0; i < n; i++)
        {
            s.Add(io.ReadInt());
        }
        io.WriteLine(s.ElementAt(s.Count-2));
    }
}
