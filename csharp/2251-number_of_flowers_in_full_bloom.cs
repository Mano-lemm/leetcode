namespace csharp;

public class _2251_number_of_flowers_in_full_bloom
{
    public int[] FullBloomFlowers(int[][] flowers, int[] people)
    {
        var bloomingDic = new Dictionary<int, int> { { 0, 0 } };
        foreach (var flower in flowers)
        {
            if (!bloomingDic.ContainsKey(flower[0]))
            {
                bloomingDic.Add(flower[0], 0);
            }
            bloomingDic[flower[0]]++;
            if (!bloomingDic.ContainsKey(flower[1] + 1))
            {
                bloomingDic.Add(flower[1] + 1, 0);
            }
            bloomingDic[flower[1] + 1]--;
        }

        var pos = new List<int>();
        var pref = new List<int>();
        var curr = 0;
        foreach (var (key, val) in bloomingDic.OrderBy((kv) => kv.Key))
        {
            pos.Add(key);
            curr += val;
            pref.Add(curr);
        }
        var r = new int[people.Length];
        for (var i = 0; i < people.Length; i++)
        {
            var left = 0;
            var right = pos.Count;
            while (left < right)
            {
                var mid = (left + right) / 2;
                if (people[i] < pos[mid])
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }
            r[i] = pref[left - 1];
        }
        return r;
    }
}
