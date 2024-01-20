using System.Text;
using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        //abc136d
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var sb = new StringBuilder(io.ReadString()); var n = sb.Length;

        for (int i = 0; i < n-1; i++)
        {
            if (sb.ToString(i,2).Equals("LR"))
            {
                sb.Insert(i+1, ' ');
                n++;
            } 
        }

        var groups = sb.ToString().Split(' ').ToList();
        var res = string.Join(' ', groups.Select(GetResult));
        io.WriteLine(res);
    }

    static string GetResult(string g)
    {
        var firstIndex = 0;
        var secondIndex = 0;
        var res = new int[g.Length];
        var cl = 0;
        var cr = 0;
        for (int i = 0; i < g.Length-1; i++)
        {
            if (g.Substring(i,2).Equals("RL"))
            {
                firstIndex = i;
                secondIndex = i+1;
                cl = i;
                cr = g.Length - i - 2;
                break;
            } 
        }


        var split = g.Split(' ');

        res[firstIndex] = 1 + cl/2 + cr/2 + (cr % 2 == 0 ? 0 : 1);
        res[secondIndex] = 1 + cl / 2 + cr / 2 + (cl% 2 == 0 ? 0 : 1);

        return string.Join(' ', res);
    }
}
