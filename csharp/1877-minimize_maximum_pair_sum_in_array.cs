namespace csharp;

public class _1877_minimize_maximum_pair_sum_in_array
{
    public int MinPairSum(int[] nums)
    {
        Array.Sort(nums);
        var min = int.MinValue;
        for (var i = 0; i < nums.Length / 2; i++)
        {
            if (nums[i] + nums[^(i + 1)] > min) min = nums[i] + nums[^(i + 1)];
        }
        return min;
    }
}