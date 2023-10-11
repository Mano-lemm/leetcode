namespace csharp;

public class _2009_minimum_number_of_operations_to_make_array_continuous
{
    public int MinOperations(int[] nums)
    {
        // make sorted version of arr
        // (n log n)
        var sorted = new List<int>(nums).OrderBy(a => a).Distinct().ToList();
        Console.WriteLine(
            "[" + sorted.Select(a => a.ToString()).Aggregate((a, b) => a + "; " + b) + "]"
        );
        // for n in sorted arr
        // n + len(arr) - 1 == end of last value of the array if it was contiguous
        var min = nums.Length - 1;
        for (int i = 0; i < sorted.Count; i++)
        {
            var target = sorted[i] + nums.Length - 1;
            var start = 0;
            var end = sorted.Count;
            var mid = (start + end) / 2;
            Console.WriteLine($"target:{target}");
            while (start < end)
            {
                mid = (start + end) / 2;
                if (sorted[mid] < target)
                {
                    start = mid + 1;
                }
                else if (sorted[mid] > target)
                {
                    end = mid;
                }
                else
                {
                    Console.WriteLine(
                        $"i:{i} sorted[i]:{sorted[i]} target:{target} sorted[mid]{sorted[mid]}"
                    );
                    // mid + 1 because target is in the list and should be included
                    // mid + 1 - i == amt of items of the contiguous list that we already have
                    if (min > nums.Length - (mid + 1 - i))
                    {
                        min = nums.Length - (mid + 1 - i);
                    }
                    break;
                }
            }
            Console.WriteLine(
                $"i:{i} sorted[i]:{sorted[i]} target:{target} mid:{mid} sorted[mid]{sorted[mid]}"
            );
            if (min > nums.Length - (mid - i))
            {
                min = nums.Length - (mid - i);
            }
        }
        return min;
    }
}
