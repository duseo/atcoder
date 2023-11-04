using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadInt();
        var s = io.ReadString();

        for (int i = 0; i < n-1; i++)
        {
            var sub = s.Substring(i, 2);
            if (sub == "ab" || sub == "ba")
            {
               io.WriteBool(true);
               return;
            } 
        }
        io.WriteBool(false);
    }
}
