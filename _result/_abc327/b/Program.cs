using System.Numerics;
using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var b = new BigInteger(io.ReadLong());
        for (int i = 1; i <= 30; i++)
        {
            if (BigInteger.Pow(i, i) == b)
            {
               io.WriteLine(i);
               return;
            } 
        }
        io.WriteLine(-1);
    }
}
