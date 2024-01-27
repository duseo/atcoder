namespace Library;

public class BinarySearch
{
    public long Low { get; set; }
    public long High { get; set; }

    public BinarySearch(long lo, long hi, Func<long, bool> isOk)
    {
        while (lo < hi)
        {
            long mid = lo + (hi - lo + 1) / 2;

            if (isOk.Invoke(mid))
            {
                lo = mid;
            }
            else
            {
                hi = mid-1;
            }
        }

        Low = lo;
        High = hi;
    }
}