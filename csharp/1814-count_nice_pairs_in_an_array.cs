namespace csharp;

public class _1814_count_nice_pairs_in_an_array
{
    private const int MOD = 1000000007;

    public static int Rev(int num)
    {
        var ca = num.ToString().ToCharArray();
        Array.Reverse(ca);
        return int.Parse(ca);
    }

    // (nums[i] - rev(nums[i])) == (nums[j] - rev(nums[j]))
    public int CountNicePairs(int[] nums)
    {
        var dp = new Dictionary<int, int>();
        var total = 0L;
        foreach (var num in nums)
        {
            if (!dp.ContainsKey(num - Rev(num)))
            {
                dp.Add(num - Rev(num), 1);
            }
            else
            {
                total = (total + dp[num - Rev(num)]) % MOD;
                dp[num - Rev(num)]++;
            }
        }

        return (int)(total % MOD);
    }
}