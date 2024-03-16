using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var s = io.ReadString();
        if (s[0] != '<' || s[s.Length-1] != '>' || s.Substring(1,s.Length-2).ToCharArray().Any(c => c != '='))
        {
           io.WriteBool(false);
           return;
        }
           io.WriteBool(true);
    }
}
