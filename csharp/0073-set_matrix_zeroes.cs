namespace csharp;

public class _0073_set_matrix_zeroes {
    public void SetZeroes(int[][] matrix)
    {
        bool firstRow = false, firstCol = false;
        for (var i = 0; i < matrix.Length; i++)
        {
            for (var j = 0; j < matrix[0].Length; j++)
            {
                if (matrix[i][j] != 0) continue;
                if (i == 0) firstCol = true;
                if (j == 0) firstRow = true;
                matrix[i][0] = 0;
                matrix[0][j] = 0;
            }
        }

        for (var i = 1; i < matrix.Length; i++)
        {
            for (var j = 1; j < matrix[0].Length; j++)
            {
                if (matrix[0][j] == 0 || matrix[i][0] == 0)
                {
                    matrix[i][j] = 0;
                }
            }
        }

        if (firstCol)
        {
            for (var i = 0; i < matrix[0].Length; i++)
            {
                matrix[0][i] = 0;
            }
        }

        if (firstRow)
        {
            for (var j = 0; j < matrix.Length; j++)
            {
                matrix[j][0] = 0;
            }
        }
    }
}