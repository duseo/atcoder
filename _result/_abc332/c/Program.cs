using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadInt();
        var m = io.ReadInt();
        var s = io.ReadString();


        var tmax = 0;
        var tn = 0;
        var tl = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '1')
            {
                tn++;
            }
            else if (s[i] == '2')
            {
                tl++;
            }
            else
            {
                var tmp = 0;
                if (tl > 0 || tn >m)
                {
                    tmp = tl + (tn - m > 0 ? tn - m : 0);
                }
                tmax = Math.Max(tmax, tmp);
                tn = 0;
                tl = 0;
            }
        }
        var x = 0;
        if (tl > 0 || tn >m)
        {
            x = tl + (tn - m > 0 ? tn - m : 0);
        }
        tmax = Math.Max(tmax, x);
        
        io.WriteLine(tmax);


    }
}
