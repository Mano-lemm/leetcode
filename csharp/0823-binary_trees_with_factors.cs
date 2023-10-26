using System.Collections.Immutable;

namespace csharp;

public class _0823_binary_trees_with_factors
{
    public int NumFactoredBinaryTrees(int[] arr)
    {
        const int maxModulo = 1000000007;
        Array.Sort(arr);
        var numbers = ImmutableHashSet.Create(arr);
        var combinations = new Dictionary<int, long>();
        foreach (var x in arr) combinations[x] = 1;
        
        foreach (var i in arr) {
            foreach (var j in arr) {
                if (j > Math.Sqrt(i)) break;
                if (i % j != 0 || !numbers.Contains(i / j)) continue;
                var temp = combinations[j] * combinations[i / j];
                combinations[i] += (i / j == j ? temp : temp * 2) % maxModulo;
            }
        }
        
        return (int)combinations.Values.Aggregate(0L, (current, val) => (current + val) % maxModulo);
    }
}
