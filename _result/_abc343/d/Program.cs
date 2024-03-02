using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadLong();
        var t = io.ReadLong();
        var scores = new long[n];
        var scoreFrequency = new Dictionary<long, long> { { 0, n } }; 
        for (var i = 0; i < t; i++)
        {
            var a = io.ReadLong() - 1; 
            var b = io.ReadLong();
            if (scoreFrequency[scores[a]] == 1)
            {
                scoreFrequency.Remove(scores[a]);
            }
            else
            {
                scoreFrequency[scores[a]]--;
            }

            scores[a] += b;
            if (!scoreFrequency.ContainsKey(scores[a]))
            {
                scoreFrequency[scores[a]] = 1;
            }
            else
            {
                scoreFrequency[scores[a]]++;
            }

            io.WriteLine(scoreFrequency.Count);
        }
    }
}
