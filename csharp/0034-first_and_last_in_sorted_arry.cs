namespace firstAndLastInSortedArray
{
    public class Solution
    {
        public int[] SearchRange(int[] nums, int target)
        {
            var low = 0;
            var high = nums.Length - 1;
            var idx = (low + high) >> 1;
            while (low <= high)
            {
                if (nums[idx] < target)
                {
                    low = idx + 1;
                }
                else if (nums[idx] > target)
                {
                    high = idx - 1;
                }
                else
                {
                    low = idx;
                    high = idx;
                    while (low - 1 > -1 && nums[low - 1] == target)
                    {
                        if (nums[low - 1] == target)
                            low--;
                    }
                    while (high < nums.Length - 1 && nums[high + 1] == target)
                    {
                        if (nums[high + 1] == target)
                            high++;
                    }
                    return new[] { low, high };
                }

                idx = (low + high) >> 1;
            }
            return new[] { -1, -1 };
        }
    }
}
