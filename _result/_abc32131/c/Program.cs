using System.Collections.Immutable;
using System.Text;
using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadInt();
        var orig = new long[n];
        var prefix = new List<long>();
        var ind = new Dictionary<long, int>();
        for (int i = 0; i < n; i++)
        {
            orig[i] = io.ReadInt();
            prefix.Add(orig[i]);  
        }

        prefix.Sort();
        for (int i = 0; i < n; i++)
        {
            if (!ind.ContainsKey(prefix[i]))
            {
               ind.Add(prefix[i],i); 
            }
            else
            {
                ind[prefix[i]] = Math.Max(ind[prefix[i]], i);
            }
        }
        for (int i = 1; i < n; i++)
        {
            prefix[i] += prefix[i - 1];
        }

        var res = new StringBuilder();
        for (int i = 0; i < n; i++)
        {
            var q = orig[i];
            var sum = prefix[n - 1] - prefix[ind[q]];
            res.Append($"{sum} ");
        }
        res.Remove(res.Length-1,1);
        io.WriteLine(res);

    }
}
