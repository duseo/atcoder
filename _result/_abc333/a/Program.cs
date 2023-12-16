using System.ComponentModel.Design;
using System.Text;
using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadInt();
        io.WriteLine(string.Join(' ', Enumerable.Range(1,n).Select(x => n)).Replace(" ", ""));
    }
}
