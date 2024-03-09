using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());
        var elements = Console.ReadLine().Split().Select(int.Parse).ToList();
        var q = int.Parse(Console.ReadLine());
        var map = new Dictionary<int, LinkedListNode<int>>();
        var linkedList = new LinkedList<int>();
        foreach (var item in elements) {
            var node = linkedList.AddLast(item);
            map[item] = node;
        }

        for (var i = 0; i < q; i++) {
            var query = Console.ReadLine().Split().Select(int.Parse).ToArray();
            if (query[0] == 1) {
                var node = map[query[1]];
                var newNode = linkedList.AddAfter(node, query[2]);
                map[query[2]] = newNode;
            } else if (query[0] == 2) {
                var node = map[query[1]];
                linkedList.Remove(node);
                map.Remove(query[1]);
            }
        }

        foreach (var item in linkedList) {
            Console.Write(item + " ");
        }
    }
}
