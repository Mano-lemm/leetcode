namespace csharp;

public class _1074_number_of_submatrices_that_sum_to_target
{
    public int NumSubmatrixSumTarget(int[][] matrix, int target)
    {
        var res = 0;
        for (var i = 0; i < matrix.Length; i++)
        {
            for (var j = 1; j < matrix[0].Length; j++)
            {
                matrix[i][j] += matrix[i][j - 1];
            }
        }

        var counter = new Dictionary<int, int>();
        for (var i = 0; i < matrix[0].Length; i++) {
            for (var j = i; j < matrix[0].Length; j++) {
                counter.Clear();
                counter.Add(0, 1);
                var cur = 0;
                for (var k = 0; k < matrix.Length; k++) {
                    cur += matrix[k][j] - (i > 0 ? matrix[k][i - 1] : 0);
                    res += counter.GetValueOrDefault(cur - target);
                    counter[cur] = counter.GetValueOrDefault(cur) + 1;
                }
            }
        }
        return res;
    }
}
