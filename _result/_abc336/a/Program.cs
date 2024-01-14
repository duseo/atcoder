using System.Text;
using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());

        var n = io.ReadInt();
        var sb = new StringBuilder();
        sb.Append("L");
        for (int i = 0; i < n; i++)
        {
            sb.Append("o");
        }
        sb.Append("ng");
        
        io.WriteLine(sb.ToString());
    }
}
