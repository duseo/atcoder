using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadInt();

        var se = new SortedSet<long>();

        var ind = 0;
        for (int i = 1; i < 10000; i += 1<<ind)
        {
            ind++;
            var x = Convert.ToString(i,2); 
           
            var jnd = 0;
            for (int j = 1; j < 10000; j += 1<<jnd)
            {
                jnd++;
               
                var y = Convert.ToString(j,2); 
               
                var knd = 0;
                for (int k = 1; k < 10000; k += 1<<knd)
                {
                    knd++;

                    var z = Convert.ToString(k,2);
                    var res = long.Parse(x) + long.Parse(y) + long.Parse(z);
                    se.Add(res);

                }
               
               
               
               
            }
           
           
        }

        long r = 0;
        using var e = se.GetEnumerator();
        for (int i = 0; i <= n; i++)
        {
            r = e.Current;
            e.MoveNext();
        } 
        io.WriteLine(r);
    }
}