using System.Text;
using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadInt();
        var sb = new StringBuilder();
        for (int i = 0; i < n; i++)
        {
            sb.Append("10");
        }
        sb.Append("1");
        io.WriteLine(sb.ToString());
    }
}
