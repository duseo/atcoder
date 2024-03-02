using System.Collections.Immutable;
using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadInt();
        var g = new BasicGraph(n);
        for (int i = 0; i < n; i++)
        {
            var edges = io.ReadIntArray(n);
            for (int j = 0; j < n; j++)
            {
                if (edges[j] == 1)
                {
                   g.AddEdge(i,j); 
                   g.AddEdge(j,i); 
                } 
            }
        }

        for (int i = 0; i < n; i++)
        {
            var edges = g.Edges[i].ToHashSet().ToList().Select(x => x + 1).OrderBy(x => x).ToList();
           io.WriteLine(string.Join(' ', edges)); 
        }


    }
}
