using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadLong();
        long result = 0;
        for (long x = 1; x * x * x <= n; x++)
        {
            long cube = x * x * x;
            if (IsPalindrome(cube))
            {
                result = cube;
            }
        }
        io.WriteLine(result);
    }

    static bool IsPalindrome(long number)
    {
        string str = number.ToString();
        for (int i = 0; i < str.Length / 2; i++)
        {
            if (str[i] != str[str.Length - 1 - i])
            {
                return false;
            }
        }
        return true;
    }
}
