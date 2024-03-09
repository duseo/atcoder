using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        string s = io.ReadString();
        int firstPipe = s.IndexOf('|');
        int lastPipe = s.LastIndexOf('|');
        string result = s.Remove(firstPipe, lastPipe - firstPipe + 1);
        Console.WriteLine(result);
    }
}
