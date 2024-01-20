using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var s = io.ReadString();
        io.WriteBool(!s.Contains("BA") && !s.Contains("CA") && !s.Contains("CB"));
    }
}
