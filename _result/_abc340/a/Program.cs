using System.Text;
using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var a = io.ReadInt();
        var b = io.ReadInt();
        var d = io.ReadInt();
        var res = new StringBuilder();
        for (int i = a; i <= b; i+=d)
        {
            res.Append($"{i} ");
        }
        io.WriteLine(res.ToString());
    }
}
