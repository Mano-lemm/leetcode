namespace csharp;

public class Pattern132
{
    public static IEnumerable<int> NaturalNumbers()
    {
        int x = 0;
        while (true)
            yield return x++;
    }

    public bool Find132pattern(int[] nums)
    {
        if (nums.Length == 0)
            return false;
        var min = new int[nums.Length];
        min[0] = nums[0];
        foreach (var (num, idx) in nums.Zip(NaturalNumbers()).Skip(1))
        {
            min[idx] = Math.Min(num, min[idx - 1]);
        }
        var s = new Stack<int>();
        foreach (var (num, idx) in nums.Zip(NaturalNumbers()).Reverse())
        {
            if (num <= min[idx])
                continue;
            if (s.Count == 0 || s.Peek() > num)
                s.Push(num);

            while (s.Count != 0 && s.Peek() <= min[idx])
            {
                s.Pop();
            }

            if (s.Count != 0 && s.Peek() < num)
            {
                return true;
            }
        }
        return false;
    }
}
