using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadInt();
        var s = io.ReadInt();
        var m = io.ReadInt();
        var l = io.ReadInt();

        var res = int.MaxValue;
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                for (int k = 0; k < 20; k++)
                {
                    if (i*6+j*8+k*12 >= n)
                    {
                        res = Math.Min(res, i * s + j * m + k * l);
                    } 
                } 
            } 
        }
        
        io.WriteLine(res);
    }
}
