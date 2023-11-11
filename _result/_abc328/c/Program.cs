using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadInt();
        var q = io.ReadInt();
        var s = io.ReadString();
        var prefix = new int[n];

        for (int i = 0; i < n-1; i++)
        {
            prefix[i + 1] = prefix[i];
            if (s[i] == s[i+1])
            {
                prefix[i + 1]++;
            } 
        }

        for (int i = 0; i < q; i++)
        {
            var l = io.ReadInt();
            var r = io.ReadInt();
            io.WriteLine(prefix[r-1] - prefix[l-1]);
        }
    }
}
