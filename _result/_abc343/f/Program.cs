using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        var parts = Console.ReadLine().Split(' ');
        var n = int.Parse(parts[0]);
        var q = int.Parse(parts[1]);
        var a = Console.ReadLine().Split().Select(x => int.Parse(x)).ToList();
        var segTree = new SegmentTree<ElementStats>(n, new ElementStats());
        for (int i = 0; i < n; i++)
        {
            segTree.Update(i + 1, ElementStats.InitializeLeaf(a[i]));
        }

        for (int i = 0; i < q; i++)
        {
            var query = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();
            if (query[0] == 1)
            {
                segTree.Update(query[1], ElementStats.InitializeLeaf(query[2]) );
            }
            else
            {
                var res = segTree.Query(query[1], query[2]+1 );
                if (res.SecondLargest <= 0)
                {
                   Console.WriteLine(0); 
                }
                else
                {
                    Console.WriteLine(res.SecondLargestCount);
                }
            }
        }
    }
}

public class ElementStats : IMonoid<ElementStats>
{
    public static ElementStats InitializeLeaf(int value)
    {
        return new ElementStats
        {
            Largest = value,
            LargestCount = 1,
            SecondLargest = int.MinValue, // Indicates no second largest at this leaf level.
            SecondLargestCount = 0
        };
    }

    public int Largest { get; set; }
    public int SecondLargest { get; set; }
    public int LargestCount { get; set; }
    public int SecondLargestCount { get; set; }

    // Assuming we're working with integers for simplicity. Adjust accordingly for other types.
    public ElementStats IdentityElement => new ElementStats { Largest = int.MinValue, SecondLargest = int.MinValue, LargestCount = 0, SecondLargestCount = 0 };
    
    public ElementStats Operate(ElementStats a, ElementStats b)
    {
        var result = new ElementStats();
    
        // Determine the overall largest and second largest, taking into account all combinations of a and b.
        int[] values = new int[] { a.Largest, b.Largest, a.SecondLargest, b.SecondLargest };
        Array.Sort(values); // Sort to easily find largest and second largest unique values.
        Array.Reverse(values); // Ensure descending order.
    
        result.Largest = values[0];
        result.SecondLargest = values[1] == values[0] ? values[2] : values[1]; // Ensure second largest is actually the second unique value.
    
        // Count occurrences of the largest and second largest.
        if (a.Largest == result.Largest) result.LargestCount += a.LargestCount;
        if (b.Largest == result.Largest) result.LargestCount += b.LargestCount;

        // For second largest, we need to check all occurrences in both segments a and b.
        if (a.Largest == result.SecondLargest) result.SecondLargestCount += a.LargestCount;
        if (b.Largest == result.SecondLargest) result.SecondLargestCount += b.LargestCount;
        if (a.SecondLargest == result.SecondLargest) result.SecondLargestCount += a.SecondLargestCount;
        if (b.SecondLargest == result.SecondLargest) result.SecondLargestCount += b.SecondLargestCount;

        // Ensure that if the largest and second largest are the same, we adjust counts correctly.
        if (result.Largest == result.SecondLargest)
        {
            result.SecondLargestCount = result.LargestCount - (a.Largest == result.Largest ? a.LargestCount : 0) - (b.Largest == result.Largest ? b.LargestCount : 0);
        }

        // Handle case where there is no valid second largest (all values in the segment are the same).
        if (result.SecondLargest == int.MinValue || result.SecondLargest == result.Largest) 
        {
            result.SecondLargestCount = 0; // No valid second largest if it matches our placeholder or is equal to the largest.
        }

        return result;
    }
}
