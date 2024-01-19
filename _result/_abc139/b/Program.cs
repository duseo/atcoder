using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var a = io.ReadInt();
        var b = io.ReadInt();

        var cur = 1;
        var num = 0;
        while (cur < b)
        {
            cur--;
            cur += a;
            num++;
        }
        io.WriteLine(num);
    }
}
