namespace csharp;

public class _0074_search_a_2d_matrix {
    public bool SearchMatrix(int[][] matrix, int target)
    {
        if (matrix == null || matrix[0] == null)
        {
            return false;
        }

        var mat = matrix.SelectMany(x => x).ToArray();
        var low = 0;
        var high = mat.Length;
        while (low < high)
        {
            var mid = (high + low) / 2;
            if (mat[mid] == target)
            {
                return true;
            } 
            if (mat[mid] < target)
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