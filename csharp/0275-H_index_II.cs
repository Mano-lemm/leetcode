namespace csharp;

public class _0275_H_index_II
{
    public int HIndex(int[] citations)
    {
        var low = 0;
        var high = citations.Length;
        var hi = 0;
        while (low <= high)
        {
            var mid = low + (high - low) / 2;
            if (citations[mid] >= citations.Length - mid)
            {
                high = mid - 1;
                hi = citations.Length - mid;
            }
            else
            {
                low = mid + 1;
            }
        }

        return hi;
    }
}