using Library;

class AtCoder
{
    static long findClosest(long diff)
    {
        var closest = Math.Pow(Math.Floor(Math.Sqrt((double)diff)), 2);
        var other1 = Math.Pow(Math.Sqrt(closest)+1, 2);
        var other2 = Math.Pow(Math.Sqrt(closest)-1, 2);
        var d1 = Math.Abs((long)closest - diff);
        var d2 = Math.Abs((long)other1 - diff);
        var d3 = Math.Abs((long)other2 - diff);
        return Math.Min(d1, Math.Min(d2, d3));
    }
    
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var d = io.ReadLong();
        var min = long.MaxValue;
        for (long i = 1; i*i <= d; i++)
        {
            min = Math.Min(min, findClosest(d - i * i));
        }
        io.WriteLine(min);
    }
}
