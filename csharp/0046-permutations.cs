namespace csharp;

public class _0046_permutations {
    public IList<IList<int>> Permute(int[] nums)
    {
        var cur = new Stack<int>();
        var result = new List<IList<int>>();
        rec(new List<int>(nums), ref cur, ref result);
        return result;
    }

    private void rec(List<int> available, ref Stack<int> cur, ref List<IList<int>> result)
    {
        foreach (var num in available)
        {
            cur.Push(num);
            if (available.Count == 1)
            {
                result.Add(new List<int>(cur));
            }
            else
            {
                rec(available.Except(new []{num}).ToList(), ref cur, ref result);
            }
            cur.Pop();
        }
    }
}