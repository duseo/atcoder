using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadInt();
        var l = io.ReadInt();
        var r = io.ReadInt();
        var arr = io.ReadIntArray(n);
        List<int> res = new();
        foreach (var ai in arr)
        {
            if (ai <= l)
            {
               res.Add(l); 
            } else if (ai >= r)
            {
                res.Add(r);
            }
            else
            {
                res.Add(ai);
            }
        }
        
        io.WriteLine(string.Join(' ', res));
    }
}
