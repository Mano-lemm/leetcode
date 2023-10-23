using System.Diagnostics.Contracts;

namespace csharp;

public class _0074_search_a_2d_matrix {
    public bool SearchMatrix(int[][] matrix, int target)
    {
        var low = 0;
        var high = matrix.Length * matrix[0].Length;
        while (low < high)
        {
            var mid = (high + low) / 2;
            var (row, col) = Math.DivRem(mid, matrix[0].Length);
            if (matrix[row][col] == target)
            {
                return true;
            } 
            if (matrix[row][col] < target)
            {
                low = mid + 1;
            }
            else
            {
                high = mid;
            }
        }

        return false;
    }    
}