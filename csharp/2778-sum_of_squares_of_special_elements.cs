namespace csharp;

public class _2778_sum_of_squares_of_special_elements
{
    public int SumOfSquares(int[] nums) {
        return nums
            .Where((_, idx) => nums.Length % (idx + 1) == 0)
            .Aggregate(0, (a, b) => a + b * b);
    }
}
