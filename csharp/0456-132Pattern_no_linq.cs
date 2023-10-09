namespace csharp;

public class Pattern132NoLinq
{
    public bool Find132pattern(int[] nums)
    {
        if (nums.Length == 0)
            return false;
        var min = new int[nums.Length];
        min[0] = nums[0];
        for (int idx = 1; idx < nums.Length; idx++)
        {
            min[idx] = Math.Min(nums[idx], min[idx - 1]);
        }
        var s = new Stack<int>();
        for (int idx = nums.Length - 1; idx >= 0; idx--)
        {
            if (nums[idx] <= min[idx])
                continue;
            if (s.Count == 0 || s.Peek() > nums[idx])
                s.Push(nums[idx]);

            while (s.Count != 0 && s.Peek() <= min[idx])
            {
                s.Pop();
            }

            if (s.Count != 0 && s.Peek() < nums[idx])
            {
                return true;
            }
        }
        return false;
    }
}
