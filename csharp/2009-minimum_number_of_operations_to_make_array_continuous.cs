namespace csharp;

public class _2009_minimum_number_of_operations_to_make_array_continuous
{
    public int MinOperations(int[] nums)
    {
        // make sorted version of arr
        // (n log n)
        var sorted = new List<int>(nums).OrderBy(a => a).Distinct().ToList();
        Console.WriteLine(
            "["
                + sorted.Select(a => a.ToString()).Aggregate((a, b) => a + "; " + b)
                + "]"
                + "len("
                + nums.Length
                + ")"
        );
        // for n in sorted arr
        // n + len(arr) - 1 == end of last value of the array if it was contiguous
        var min = nums.Length - 1;
        for (int i = 0; i < sorted.Count; i++)
        {
            var target = sorted[i] + nums.Length - 1;
            var start = 0;
            var end = sorted.Count;
            Console.WriteLine($"target:{target}");
            while (start < end)
            {
                var mid = (start + end) / 2;
                if (sorted[mid] <= target)
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid;
                }
            }
            Console.WriteLine(
                $"i:{i} sorted[i]:{sorted[i]} target:{target} start:{start} sorted[start]:{(sorted.Count > start ? sorted[start] : "EOA")}"
            );
            min = Math.Min(min, nums.Length - (start - i));
        }
        return min;
    }
}
