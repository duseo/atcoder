using System.Numerics;
using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var a = new BigInteger(io.ReadLong());
        var m = new BigInteger(io.ReadLong());
        var l = new BigInteger(io.ReadLong());
        var r = new BigInteger(io.ReadLong());

        l -= a;
        r -= a;

        Func<BigInteger, BigInteger> Floor = delegate(BigInteger num)
        {
            if (num < 0)
            {
                var abs = BigInteger.Abs(num);
                var res = abs / m;
                if (m * res < abs)
                {
                    res++;
                }

                return -1 * res;
            }
            else
            {
                return num / m;
            }
        };

        var res = BigInteger.Max(0, Floor(r) - Floor(l - 1));
        io.WriteLine(res);
    }
}

