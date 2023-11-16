using System.Text;
using BenchmarkDotNet.Attributes;

namespace csharp.BenchMarks;

public class _1980_benchmark
{
    [Params(10, 100, 1000, 2000, 3000, 4000)]
    public int N { get; set; }
    private string[] data { get; set; }
    private static _1980_find_unique_binary_string solution { get; } = new();

    [GlobalSetup]
    public void GlobalSetup()
    {
        var rand = new Random();
        var sb = new StringBuilder();
        var genRandoms = (int n) => Enumerable
            .Range(0, n)
            .Select(_ =>
            {
                for (var i = 0; i < n; i++)
                {
                    sb.Append('0' + rand.Next(2));
                }

                var r = sb.ToString();
                sb.Clear();
                return r;
            }).ToArray();
        data = genRandoms(N); // executed once per each N value
    }

    [Benchmark]
    public string ForLoop() => solution.FindDifferentBinaryString(data);

    [Benchmark]
    public string LINQQuery() => solution.FindDifferentBinaryStringLINQ(data);
}