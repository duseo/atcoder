using System.Text;
using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var sb = new StringBuilder(io.ReadString());
        sb[^1] = '4';
        io.WriteLine(sb.ToString());
    }
}
