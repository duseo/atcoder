using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var s1 = io.ReadChar();
        var s2 = io.ReadChar();
        var t1 = io.ReadChar();
        var t2 = io.ReadChar();

        var s = "ABCDEABCDE";

        Func<char,char,int> GetCount = delegate(char x1, char x2)
        {
            var count = 0;
            var forward = 0;
            var backward = 0;
            bool start = false;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == x1)
                {
                    start = true;
                    continue;
                }

                if (start)
                {
                    count++;
                    if (s[i] == x2)
                    {
                        forward = count;
                        break;
                    }
                    
                }
            }

            start = false;
            count = 0;
            
            for (int i = s.Length-1; i >= 0; i--)
            {
                if (s[i] == x1)
                {
                    start = true;
                    continue;
                }

                if (start)
                {
                    count++;
                    if (s[i] == x2)
                    {
                        backward = count;
                        break;
                    }
                    
                }
            }

            return Math.Min(backward, forward);
        };
        
        io.WriteBool(GetCount(s1,s2) == GetCount(t1,t2));

    }
}
