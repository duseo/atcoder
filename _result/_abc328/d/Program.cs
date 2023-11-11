using System.Text;
using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var s = io.ReadString();
        var res = new StringBuilder();
        for (int i = 0; i < s.Length; i++)
        {
            res.Append(s[i]);
            if (res.Length >= 3 && res.ToString(res.Length-3,3) == "ABC")
            {
                res.Remove(res.Length - 3, 3);
            }
        }
        io.WriteLine(res);
    }
}
