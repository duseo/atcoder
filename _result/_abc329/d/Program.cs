using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadInt();
        var m = io.ReadInt();
        var s = new SortedDictionary<int, SortedSet<int>>();
        var votes = new SortedDictionary<int, int>();
        for (int i = 0; i < m; i++)
        {
            var v = io.ReadInt();
            if (!votes.ContainsKey(v))
            {
                votes.Add(v, 0);
            }
            votes[v]++;
            
            if (!s.ContainsKey(votes[v]))
            {
               s.Add(votes[v], new SortedSet<int>()); 
            }

            s[votes[v]].Add(v);

            io.WriteLine(s[s.Count].First());
        }
    }
}
