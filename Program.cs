using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var input = io.ReadString();
        if (input[0].ToString() != input[0].ToString().ToUpper())
        {
            io.WriteBool(false);
            return;
        }

        var arr = input.ToCharArray().TakeLast(input.Length-1).ToArray();
        var s = new string(arr);
        if (s.ToLower() != s)
        {
            io.WriteBool(false);
            return;
        }
        
        io.WriteBool(true);
    }
}
