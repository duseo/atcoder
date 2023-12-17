using System.Text;
using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());

        var l = new SortedSet<long>();
        for (var i = new StringBuilder("1"); i.Length < 13; i.Append('1'))
        {
            for (var j = new StringBuilder("1"); j.Length < 13; j.Append("1"))
            {
                for (var k = new StringBuilder("1"); k.Length < 13; k.Append("1"))
                {
                    l.Add(long.Parse(i.ToString()) + long.Parse(j.ToString()) + long.Parse(k.ToString()));    
                }
            }
        }

        io.WriteLine(l.GetNthElement(io.ReadInt()));
    }
}