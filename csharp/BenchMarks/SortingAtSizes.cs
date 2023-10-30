using System.Runtime.Intrinsics.X86;
using BenchmarkDotNet.Attributes;

namespace csharp.BenchMarks;

[DisassemblyDiagnoser]
public class SortingAtSizes
{
    [Params(10, 50, 100, 200, 300, 400, 500)]
    public int Size;

    private Random _random = new Random();
    private int[] xs;

    [IterationSetup]
    public void Setup()
    {
        xs = new int[Size];
        for (var i = 0; i < Size; i++)
        {
            xs[i] = _random.Next();
        }
    }

    [Benchmark]
    public void ArraySort()
    {
        Array.Sort(xs, (i, i1) =>  
          Popcnt.PopCount((uint)i) - Popcnt.PopCount((uint)i1) != 0 
              ? (int)(Popcnt.PopCount((uint)i) - Popcnt.PopCount((uint)i1)) 
              : i - i1);
    }
    
    [Benchmark]
    public void LinqSort()
    {
        var array = xs.OrderBy(i => Popcnt.PopCount((uint)i)).ThenBy(i => i).ToArray();
    }

    [Benchmark]
    public void InsertionSort()
    {
        int tmpIdx;
        int tmpVal;
        for (var i = 0; i < xs.Length; i++)
        {
            tmpIdx = i;
            for (var j = i + 1; j < xs.Length; j++)
            {
                if (Popcnt.PopCount((uint)xs[tmpIdx]) < Popcnt.PopCount((uint)xs[j]))
                {
                    tmpIdx = j;
                    continue;
                }

                if (xs[tmpIdx] < xs[j])
                {
                    tmpIdx = j;
                }
            }

            tmpVal = xs[i];
            xs[i] = xs[tmpIdx];
            xs[tmpIdx] = tmpVal;
        }
    }
}