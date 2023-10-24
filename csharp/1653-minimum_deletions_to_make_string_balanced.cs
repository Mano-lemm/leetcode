namespace csharp;

public static class LinqExtension
{
    public static IEnumerable<TAccumulate> Scan<TSource, TAccumulate>(this IEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> accumulator)
    {
        var acc = new List<TAccumulate>() { seed };
        var curr = seed;
        foreach (var item in source)
        {
            curr = accumulator(curr, item);
            acc.Add(curr);
        }
        return acc;
    }
    
    public static IEnumerable<TAccumulate> ScanBack<TSource, TAccumulate>(this IEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> accumulator)
    {
        var acc = new List<TAccumulate>() { seed };
        var curr = seed;
        foreach (var item in source.Reverse())
        {
            curr = accumulator(curr, item);
            acc.Insert(0, curr);
        }
        return acc;
    }
}

public class _1653_minimum_deletions_to_make_string_balanced {
    // dynamic programming solution
    public int MinimumDeletions(string s)
    {
        int cntb = 0, res = 0;
        foreach (var x in s) {
            if (x == 'a') res = Math.Min(++res, cntb);
            else if (x == 'b') ++cntb;
        }
        return res;
    }
    
    public int MinimumDeletionsFunctional(string s)
    {
        var axs = s
            .Select(x => x == 'a' ? 1 : 0)
            .ScanBack(0, (x, y) => x + y);
        var bxs = s
            .Select(x => x == 'a' ? 1 : 0)
            .Scan(0, (x, y) => x + y);
        return axs
            .Zip(bxs)
            .Select(x => x.First + x.Second).Min();
    }
    
    public int MinimumDeletionsImperative(string s)
    {
        var acr = 0;
        var axs = new List<int>() {acr};
        var bcr = 0;
        var bxs = new List<int>() {bcr};
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == 'b')
            {
                bcr++;
            }

            if (s[^(i + 1)] == 'a')
            {
                acr++;
            }
            axs.Insert(0, acr);
            bxs.Add(bcr);
        }

        var min = int.MaxValue;
        foreach (var VARIABLE in axs.Zip(bxs))
        {
            if (VARIABLE.First + VARIABLE.Second < min)
            {
                min = VARIABLE.First + VARIABLE.Second;
            }
        }

        return min;
    } 
}