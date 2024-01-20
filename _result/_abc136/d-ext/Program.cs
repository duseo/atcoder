using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        string n = io.ReadString();
        var res = n.GroupByPattern("LR")
            .Select(group => group.TransformToResult())
            .ToList()
            .Join(' ');
        io.WriteLine(res);
    }

}
