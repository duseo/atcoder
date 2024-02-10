using Library;

class AtCoder
{
    static void Main(string[] args)
    {
            int Q = int.Parse(Console.ReadLine());
    
            List<int> A = new List<int>();
    
            for (int i = 0; i < Q; i++)
            {
                var query = Console.ReadLine().Split(' ');
                var queryType = int.Parse(query[0]);

                if (queryType == 1)
                {
                    int x = int.Parse(query[1]);
                    A.Add(x);
                }
                else if (queryType == 2)
                {
                    int k = int.Parse(query[1]);
                    Console.WriteLine(A[^k]);
                }
            }
    }
}
