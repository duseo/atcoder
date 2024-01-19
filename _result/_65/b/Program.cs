using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        //abc65b
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadInt();
        var a = io.ReadIntArray(n);

        var res = 0;
        var cur = 1;
        for (int i = 0; i < n; i++)
        {
            if (cur == 2)
            {
                io.WriteLine(res);
                return;
            }

            cur = a[cur - 1];
            res++;
        }
        io.WriteLine(-1);
    }
}
