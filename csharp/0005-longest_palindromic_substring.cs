namespace csharp;

public class _0005_longest_palindromic_substring
{
    private static void PrintBoolMatrix(bool[][] mat)
    {
        Console.WriteLine(mat.Select(x => x.Select(b => b ? "true " : "false").Aggregate((a, b) => a + " " + b))
            .Aggregate((a, b) => a + "\n" + b));
    }
    
    public string LongestPalindrome(string s)
    {
        var start = 0;
        var len = 1;
        for (var i = 0; i < s.Length; i++)
        {
            for (var j = 1; i - j >= 0 && i + j < s.Length; j++)
            {
                if (s[i - j] != s[i + j]) break;
                if (i + j - (i - j) + 1 <= len) continue;
                start = i - j;
                len = i + j - (i - j) + 1;
            }
            for (var j = 0; i - j >= 0 && i + j + 1 < s.Length; j++)
            {
                if (s[i - j] != s[i + j + 1]) break;
                if (i + j + 1 - (i - j) + 1 <= len) continue;
                start = i - j;
                len = i + j + 1 - (i - j) + 1;
            }
        }
        
        return s.Substring(start, len);
    }
}
