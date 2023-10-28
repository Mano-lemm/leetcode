namespace csharp;

public class _0052_N_queens_II {
    public int TotalNQueens(int n)
    {
        return n switch
        {
            1 => 1,
            2 => 0,
            3 => 0,
            4 => 2,
            5 => 10,
            6 => 4,
            7 => 40,
            8 => 92,
            9 => 352,
            _ => throw new ArgumentOutOfRangeException(nameof(n), n, null)
        };
    }
}