using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
       var x = io.ReadInt();
       var s = Convert.ToString(x, 2);
       var res = 0;
       for (int i = s.Length-1; i >= 0; i--)
       {
           if (s[i] == '0')
           {
               res++;
           }
           else
           {
               break;
           }
       }
       io.WriteLine(res);

    }
}
