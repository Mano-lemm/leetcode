namespace csharp;

public class _1424_diagonal_traverse_II
{
    public int[] FindDiagonalOrder(IList<IList<int>> nums)
    {
        var groups = new Dictionary<int, List<int>>();

        for (var row = nums.Count - 1; row >= 0; row--)
        {
            for (var col = 0; col < nums[row].Count; col++)
            {
                var diagonal = row + col;
                if (!groups.TryGetValue(diagonal, out var value))
                {
                    value = new List<int>();
                    groups[diagonal] = value;
                }

                value.Add(nums[row][col]);
            }
        }

        var ans = new List<int>();
        var curr = 0;

        while (groups.ContainsKey(curr))
        {
            ans.AddRange(groups[curr]);
            curr++;
        }

        return ans.ToArray();
    }
}