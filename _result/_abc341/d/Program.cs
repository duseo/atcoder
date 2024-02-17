using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine().Split(' ');
        var n = long.Parse(input[0]);
        var m = long.Parse(input[1]);
        var k = long.Parse(input[2]);

        if (k == 1)
        {
            Console.WriteLine(Math.Min(n,m));
            return;
        }
        
        long GetLcm(long a, long b) {
             return a / GetGcd(a, b) * b;
        }
         
        long GetGcd(long a, long b) {
           while (b != 0) {
                   var temp = b;
                   b = a % b;
                   a = temp;
           }
           return a;
       }
        
        var lcm = GetLcm(n, m);
        bool IsGood(long mid)
        {
            return  mid / n + mid / m - 2 * (mid / lcm) < k;
        }
        
       var bs = new BinarySearch(1, long.MaxValue, IsGood);


       Console.WriteLine($"{bs.Low+1}");
    }
}
