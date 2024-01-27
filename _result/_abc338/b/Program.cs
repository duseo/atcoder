using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());

        var s = io.ReadString().ToCharArray();

        var sd = new SortedDictionary<char, int>();

        foreach (var c in s)
        {
            if (sd.TryGetValue(c, out var num))
            {
                sd[c] = num + 1;
            }
            else
            {
                sd[c] = 1;
            }
        }

        char max = '1';
        var maxc = 0;

        foreach (var kvp in sd)
        {
            if (kvp.Value > maxc)
            {
                max = kvp.Key;
                maxc = kvp.Value;
            } 
        }
        
        io.WriteLine(max);

    }
}
