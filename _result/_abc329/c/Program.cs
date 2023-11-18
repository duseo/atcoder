using Library;

class AtCoder
{
    static int GetCount(char c, string s)
    {
        var m = 0;
        var cnt = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == c)
            {
                cnt++;
                m = Math.Max(cnt, m);
            }
            else
            {
                cnt = 0;
                m = Math.Max(cnt, m);
            }
        }

        return m;
    }
    
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var res = 0;
        var n = io.ReadInt();
        var s = io.ReadString();
        for (char ch = 'a'; ch <= 'z'; ch++)
        {
            res += GetCount(ch, s);
        }
        io.WriteLine(res);
    }
}
