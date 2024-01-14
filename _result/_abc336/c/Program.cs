using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var x = io.ReadLong();
        if (x==1)
        {
           io.WriteLine(0);
           return;
        }
        io.WriteLine(convert(x-1,5));
    }
    
    public static string convert(long decimalNumber, int radix)
    {
        const int BitsInLong = 64;
        const string Digits = "0246856789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        int index = BitsInLong - 1;
        long currentNumber = Math.Abs(decimalNumber);
        char[] charArray = new char[BitsInLong];

        while (currentNumber != 0)
        {
            int remainder = (int)(currentNumber % radix);
            charArray[index--] = Digits[remainder];
            currentNumber = currentNumber / radix;
        }

        string result = new String(charArray, index + 1, BitsInLong - index - 1);

        return result;
    }
}
