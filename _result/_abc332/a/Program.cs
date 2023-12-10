using Library;

class Oracle : IOracle<int>
{
    public int IdentityElement => Int32.MinValue;
    public int Operate(int a, int b)
    {
        return Math.Max(a, b);
    }
}

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadInt();
        var s = io.ReadInt();
        var k = io.ReadInt();
        var res = 0;
        for (int i = 0; i < n; i++)
        {
            var p = io.ReadInt();
            var q = io.ReadInt();
            res += p * q;
        }
        res += (res < s ? k : 0);
        io.WriteLine(res);
    }
    
}
