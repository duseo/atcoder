using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        //abc141d
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadInt();
        var m = io.ReadInt();

        var pq = new PriorityQueue<long>();

        for (int i = 0; i < n; i++)
        {
            pq.Enqueue(-1 * io.ReadLong());
        }

        while (m > 0)
        {
            var tmp = pq.Peek() / 2;
            pq.Dequeue();
            pq.Enqueue(tmp);
            m--;
        }

        var res = 0L;

        while (pq.Any())
        {
            var el = pq.Dequeue(); 
            res += -1 * el;
        }
        
        io.WriteLine(res);
        
        
    }
}
