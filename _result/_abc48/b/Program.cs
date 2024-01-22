using System.Text;
using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        //abc48b
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var a = io.ReadLong();
        var b = io.ReadLong();
        var x = io.ReadLong();
        if (a%x != 0)
        {
            a = a - a % x + x;
        }
        b -= b % x;
        
        io.WriteLine((b-a)/x + 1);


    }
}
