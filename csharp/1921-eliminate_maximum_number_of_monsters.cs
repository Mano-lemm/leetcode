namespace csharp;

public class _1921_eliminate_maximum_number_of_monsters
{
    public static IEnumerable<int> nat(){
        var i = 0;
        while(true)
            yield return i++;
    }

    public int EliminateMaximum(int[] dist, int[] speed) {
        var r = dist
            .Zip(speed)
            .Select(x => x.First / (double)x.Second)
            .OrderBy(x => x)
            .Zip(nat())
            .FirstOrDefault(x => x.First <= x.Second);
        var rr = r.Second;
        return rr == 0 ? dist.Length : rr;
    }
}
