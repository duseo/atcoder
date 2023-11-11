using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadInt();
        var x = io.ReadInt();
        var res = 0; 
        for (int i = 0; i < n; i++)
        {
            var tmp = io.ReadInt();
            if (tmp <= x)
            {
                res += tmp;
            }
        }
        io.WriteLine(res);
    }
}
