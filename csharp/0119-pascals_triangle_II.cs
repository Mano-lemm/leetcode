namespace csharp;

public class _0119_pascals_triangle_II
{
    public IList<int> GetRow(int rowIndex)
    {
        var pt = new List<int>() { 1 };
        while (pt.Count < rowIndex)
        {
            var tmp = new List<int>();
            for (int i = 0; i < pt.Count + 1; i++)
            {
                tmp.Add((i - 1 >= 0 ? pt[i - 1] : 0) + (i < pt.Count ? pt[i] : 0));
            }
            pt = tmp;
        }
        return pt;
    }
}
