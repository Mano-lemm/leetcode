using System.Text;

namespace csharp;

public class _0051_N_queens
{
    private IList<IList<char>> _board;
    private IList<IList<string>> _r;
    private int _n;
    
    public IList<IList<string>> SolveNQueens(int n)
    {
        _board = new List<IList<char>>();
        _r = new List<IList<string>>();
        for (var i = 0; i < n; i++)
        {
            _board.Add(new List<char>());
            for (int j = 0; j < n; j++)
            {
                _board[i].Add('.');
            }
        }

        _n = n;

        SolveNQueensrec(0);
        return _r;
    }

    private bool InRange(int x, int y)
    {
        return x >= 0 && x < _n && y >= 0 && y < _n;
    }

    private bool CanPutQueen(int x, int y)
    {
        for (var i = 1; i < _n; i++)
        {
            if (InRange(x - i, y - i) &&
                _board[x - i][y - i] == 'Q') return false;

            if (InRange(x - i, y + i) &&
                _board[x - i][y + i] == 'Q') return false;
            
            if (InRange(x + i, y - i) &&
                _board[x + i][y - i] == 'Q') return false;

            if (InRange(x + i, y + i) &&
                _board[x + i][y + i] == 'Q') return false;
            
            if (InRange(x - i, y) &&
                _board[x - i][y] == 'Q') return false;

            if (InRange(x + i, y) &&
                _board[x + i][y] == 'Q') return false;
            
            if (InRange(x, y - i) &&
                _board[x][y - i] == 'Q') return false;

            if (InRange(x, y + i) &&
                _board[x][y + i] == 'Q') return false;
        }
        return true;
    }

    private void SolveNQueensrec(int idx)
    {
        if (idx == _n * _n)
        {
            var containsNQueens = _board
                .SelectMany(s => s)
                .Count(c => c == 'Q') == _n;
            if (containsNQueens)
            {
                var l = _board
                    .Select(chars => chars
                        .Aggregate(new StringBuilder(chars.Count), (s, c) => s.Append(c)))
                    .Select(sb => sb.ToString())
                    .ToList();
                _r.Add(l);
            }
            return;
        }
        var (x, y) = Math.DivRem(idx, _n);
        if (CanPutQueen(x, y))
        {
            _board[x][y] = 'Q';
            SolveNQueensrec(idx + 1);
            _board[x][y] = '.';
        }
        SolveNQueensrec(idx + 1);
    }
}