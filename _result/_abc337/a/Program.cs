using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadInt();
        var x = 0;
        var y = 0;
        for (int i = 0; i < n; i++)
        {
            x += io.ReadInt();
            y += io.ReadInt();
        }

        if (x>y)
        {
           io.WriteLine("Takahashi"); 
        }
        else if (x < y)
        {
           io.WriteLine("Aoki"); 
        }
        else
        {
            io.WriteLine("Draw");
        }
    }
}
