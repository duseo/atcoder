using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        // abc156c
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadInt();
        var x = io.ReadIntArray(n);
        io.WriteLine(Enumerable.Range(1, 100).Select(p => x.Sum(tmp => Math.Pow(tmp - p, 2))).Min());
    }
}
