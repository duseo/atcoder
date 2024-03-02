using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var a = io.ReadInt();
        var b = io.ReadInt();
        io.WriteLine((a+b+1)%9);
    }
}
