using Library;

class AtCoder
{
    private static readonly Dictionary<(int, string), int> Memo = new();

    static int MinCost(string t, List<List<string>> bags, int bagIndex, string current) {
        if (current == t) return 0;
        if (bagIndex >= bags.Count || current.Length >= t.Length) return -1;
        if (Memo.ContainsKey((bagIndex, current))) return Memo[(bagIndex, current)];

        var minCost = int.MaxValue;
        foreach (var str in bags[bagIndex]) {
            if (t.StartsWith(current + str)) {
                int cost = MinCost(t, bags, bagIndex + 1, current + str);
                if (cost != -1) {
                    minCost = minCost == int.MaxValue ? cost + 1 : Math.Min(minCost, cost + 1);
                }
            }
        }
        int skipCost = MinCost(t, bags, bagIndex + 1, current);
        if (skipCost != -1) {
            minCost = minCost == int.MaxValue ? skipCost : Math.Min(minCost, skipCost);
        }

        int finalCost = minCost == int.MaxValue ? -1 : minCost;
        Memo[(bagIndex, current)] = finalCost;
        return finalCost;
    }
    
    static void Main(string[] args) {
        string t = Console.ReadLine();
        int n = int.Parse(Console.ReadLine());
        var bags = new List<List<string>>(n);
        for (int i = 0; i < n; i++) {
            var parts = Console.ReadLine().Split(' ');
            bags.Add(parts.Skip(1).ToList());
        }
        int result = MinCost(t, bags, 0, "");
        Console.WriteLine(result);
    }
}
