namespace csharp;

public class _2849_determine_if_a_cel_is_reachable_at_a_given_time
{
    public bool IsReachableAtTime(int sx, int sy, int fx, int fy, int t) 
    {
	var minDist = Math.Min(Math.Abs(fx - sx), Math.Abs(fy - sy)) + Math.Abs(Math.Abs(fy - sy) - Math.Abs(fx - sx));
        if (minDist == 0) {
            return t == 1 ? false : true;
        }
        return t >= minDist;
    }
}
