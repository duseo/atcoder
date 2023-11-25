using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadInt();
        var k = io.ReadInt();
        var arr = io.ReadIntArray(n);
        io.WriteLine(arr.Count(x => x >= k));
    }
}
