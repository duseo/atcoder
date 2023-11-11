using System.IO.IsolatedStorage;
using Library;

class AtCoder
{
    static bool IsOk(int[] c, int month)
    {
        for (int i = 0; i < c.Length; i++)
        {
            if (month != c[i])
            {
                return false;
            } 
        }

        return true;
    }
    
    static int GetCount(int month, int nDays)
    {
        var cnt = 0;
        for (int i = 1; i <= nDays; i++)
        {
            var tmp = i.ToString().ToCharArray();
            var tmp2 = month.ToString().ToCharArray().Select(c => c - '0').ToArray();
            if (IsOk(tmp.Select(c => c - '0').ToArray(), tmp2[0]) && IsOk(tmp2, tmp2[0]))
            {
                cnt++;
            }
        }
        return cnt;
    }
    
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadInt();
        var mo = io.ReadIntArray(n);
        var res = 0;
        for (int i = 0; i < n; i++)
        {
            res += GetCount(i+1, mo[i]);
        }
        io.WriteLine(res);
    }
}
