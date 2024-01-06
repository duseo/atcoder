using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadInt();
        var q = io.ReadInt();
        var coords = new List<(int, int)>();
        for (int i = 1; i <= n ; i++)
        {
            coords.Add((i, 0));
        }

        coords.Reverse();


        for (int i = 0; i < q; i++)
        {

            var t = io.ReadInt();
            if (t == 1)
            {
                var tt = io.ReadChar();
                var head = coords.Last();
                if (tt == 'R')
                {
                    coords.Add((head.Item1+1,head.Item2));
                }
                if (tt == 'L')
                {
                    coords.Add( (head.Item1-1,head.Item2));
                }
                if (tt == 'U')
                {
                    coords.Add( (head.Item1,head.Item2+1));
                
                }
                if (tt == 'D')
                {
                    coords.Add( (head.Item1,head.Item2-1));
                }
            }
            
            if (t == 2)
            {
                var p = io.ReadInt();
                io.WriteLine($"{coords[^p].Item1} {coords[^p].Item2}");
            }
        }
    }
}
