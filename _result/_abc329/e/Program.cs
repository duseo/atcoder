using System.Runtime.InteropServices.JavaScript;
using System.Text;
using Library;

class AtCoder
{
    
    static bool IsEqual(string rf, string t) 
    {
        for (int i = 0; i < rf.Length; i++)
        {
            if (rf[i] != '*' && rf[i] != t[i])
            {
                return false;
            } 
        }

        return true;
    }
    
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadInt();
        var m = io.ReadInt();
        var s = io.ReadString();
        var t = io.ReadString();

        var st = new string('*', m);

        var sb = new StringBuilder(s);

        for (int i = 0; i < n - m + 1; i++)
        {
            if (IsEqual(sb.ToString(i,m), t))
            {
                sb.Replace(sb.ToString(i, m), st, i, m);
            }    
        }

        for (int i = n - 1; i >= m; i--)
        {
            if (IsEqual(sb.ToString(i-m,m), t))
            {
                sb.Replace(sb.ToString(i-m, m), st, i-m, m);
            }    
        }

        io.WriteBool(sb.Equals(new string('*', n)));
    }
}