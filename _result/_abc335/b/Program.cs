using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadInt();
        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j < n+1; j++)
            {
                for (int k = 0; k < n+1; k++)
                {
                    if (i + j + k <= n)
                    {
                       io.WriteLine($"{i} {j} {k}"); 
                    } 
                } 
            } 
            
        }
    }
}
