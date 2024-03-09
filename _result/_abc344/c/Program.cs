using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        int N = int.Parse(Console.ReadLine() ?? string.Empty);
        int[] A = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int M = int.Parse(Console.ReadLine() ?? string.Empty);
        int[] B = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int L = int.Parse(Console.ReadLine() ?? string.Empty);
        int[] C = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int Q = int.Parse(Console.ReadLine() ?? string.Empty);
        int[] X = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        HashSet<int> ABsums = new HashSet<int>();
        foreach (int a in A) {
            foreach (int b in B) {
                ABsums.Add(a + b);
            }
        }

        for (int i = 0; i < Q; i++) {
            bool found = false;
            foreach (int c in C) {
                if (ABsums.Contains(X[i] - c)) {
                    Console.WriteLine("Yes");
                    found = true;
                    break;
                }
            }
            if (!found) {
                Console.WriteLine("No");
            }
        }
    }
}
