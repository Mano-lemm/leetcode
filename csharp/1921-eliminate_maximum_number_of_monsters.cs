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
    
    public int EliminateMaximumCountingSort(int[] dist, int[] speed){
        var n = dist.Length;
        for (var i = 0; i < n; i++) {
            dist[i] = (int) Math.Ceiling(dist[i] /(double) speed[i]);
            speed[i] = 0;
        }
        foreach(var num in dist) {
            if (num >= n) continue;
            speed[num]++;
        }
        for (var i = 1; i < n; i++) {
            speed[i] += speed[i - 1];
            if (speed[i] > i) {
                return i;
            }
        }
        return n;
    }
}
