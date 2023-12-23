using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        io.WriteLine(io.ReadInt() > io.ReadInt() ? "Bat" : "Glove");
    }
}
