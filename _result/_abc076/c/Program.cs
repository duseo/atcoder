using System.Diagnostics;
using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        //abc76c
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var s = io.ReadString();
        var t = io.ReadString();
        var res = -1;
        for (int i = 0; i < s.Length - t.Length + 1; i++)
        {
            if (IsMatch(s.Substring(i, t.Length), t))
            {
                res = i;
            } 
        }

        if (res == -1)
        {
            io.WriteLine("UNRESTORABLE");
            return;
        }
        
        var arr = s.ToCharArray();
        for (int i = 0; i < t.Length; i++)
        {
            arr[i+res] = t[i];
        }
        io.WriteLine(new string(arr).Replace('?', 'a'));
    }

    private static bool IsMatch(string s, string t)
    {
       Debug.Assert(s.Length == t.Length);
       for (int i = 0; i < s.Length; i++)
       {
           if (s[i] != '?' && s[i] != t[i])
           {
               return false;
           }
       }
       return true;
    }
}
