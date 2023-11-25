using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadInt();
        var m = new string[n];
        var rows = new long[n];
        var cols = new long[n];
        for (var i = 0; i < n; i++)
        {
            m[i] = io.ReadString();
            for (var j = 0; j < n; j++)
            {
                if (m[i][j] == 'o')
                {
                    rows[i]++;
                    cols[j]++;
                }
            }
        }

        long res = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (m[i][j] == 'o')
                {
                    res+=(rows[i] -1) *  (cols[j] -1);
                }
            } 
        }
        io.WriteLine(res);

    }
}
