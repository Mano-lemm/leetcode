namespace csharp;

public class _0448_find_all_numbers_disappeared_in_an_array
{
    public static IEnumerable<int> Nat()
    {
        var i = 1;
        while (true)
            yield return i++;
    }

    public IList<int> FindDisappearedNumbers(int[] nums)
    {
        return Nat()
            .Take(nums.Length)
            .Except(nums)
            .ToList();
    }

    public IList<int> FindDisappearedNumbers2(int[] nums)
    {
        return Nat()
            .Except(nums)
            .TakeWhile(x => x < nums.Length)
            .ToList();
    }
}
