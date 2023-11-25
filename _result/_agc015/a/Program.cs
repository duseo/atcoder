using Library;

class AtCoder
{
    static int F(int x) => Enumerable.Range(1, x).Aggregate(1, (p, i) => p * i);
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        long n = io.ReadInt();
        long a = io.ReadInt();
        long b = io.ReadInt();
        if (n == 1 && b != a || a > b)
        {
           io.WriteLine(0);
           return;
        }

        var min = a * (n - 1) + b;
        var max = b * (n - 1) + a;
        
        io.WriteLine(max-min+1);
    }
}
