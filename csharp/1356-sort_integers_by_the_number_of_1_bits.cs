using System.Numerics;
using System.Runtime.Intrinsics.X86;

namespace csharp;

public class _1356_sort_integers_by_the_number_of_1_bits
{
    public int[] SortByBits(int[] arr)
    {
        return arr.OrderBy(i => BitOperations.PopCount((uint)i)).ThenBy(x => x).ToArray();
    }
    
    public int[] SortByBitsInPlace(int[] arr)
    {
        Array.Sort(arr, (i, i1) => 
            Popcnt.PopCount((uint)i) - Popcnt.PopCount((uint)i1) != 0 
                ? (int)(Popcnt.PopCount((uint)i) - Popcnt.PopCount((uint)i1)) 
                : i - i1);
        return arr;
    }
}
