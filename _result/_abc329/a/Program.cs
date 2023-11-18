using System.Runtime.InteropServices;
using System.Text;
using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var s = io.ReadString();
        for (int i = 0; i < s.Length; i++)
        {
           io.Write(s[i]); 
           io.Write(' ');
        }
        io.WriteLine("");
    }
}
