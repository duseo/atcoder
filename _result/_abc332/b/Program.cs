using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var k = io.ReadInt();
        var g = io.ReadInt();
        var m = io.ReadInt();

        var cg = 0;
        var cm = 0;

        for (int i = 0; i < k; i++)
        {
            if (cg == g)
            {
                cg = 0;
            } 
            else if (cm == 0)
            {
                cm = m;
            }
            else
            {
                var tcg = cg + cm;
                if (tcg >= g)
                {
                    cm -= (g - cg);
                    cg = g;
                }
                else
                {
                    cg += cm;
                    cm = 0;
                }
            }
        }
        io.WriteLine($"{cg} {cm}");
        
    }
}
