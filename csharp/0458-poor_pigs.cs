namespace csharp;

public class _0458_poor_pigs
{
    // this was just a math problem
    // no programming skill involved unfortunately
    public int PoorPigs(int buckets, int minutesToDie, int minutesToTest) {
        var c = 0;
        while(Math.Pow(minutesToTest / minutesToDie + 1, c) < buckets)
            c++;
        return c;
    }
}
