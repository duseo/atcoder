using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var res = new Dictionary<int, int>();
        var n = io.ReadInt();
        for (int i = 0; i < n; i++)
        {
            var tmp = io.ReadInt();
            if (!res.ContainsKey(tmp))
            {
                res[tmp] = 0;
            }
            res[tmp]++;
        }

        var k = 0;
        foreach (var kvp in res)
        {
            if (kvp.Value > 1)
            {
                k += kvp.Value - 1;
            } 
        }
        io.WriteLine(k);
    }
}
