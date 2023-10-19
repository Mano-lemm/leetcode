using System.Text.RegularExpressions;

namespace csharp;

public class _0844_backspace_string_compare
{
    public bool BackSpaceCompare(string s, string t)
    {
        for (int i = 1, j = 1; true ; i++, j++)
        {
            var skip = 0;
            while (i < s.Length && s[^i] == '#')
            {
                skip = 0;
                while (i < s.Length && (s[^i] == '#' || skip != 0))
                {
                    skip += (s[^i] == '#' ? 1 : -1);
                    i++;
                }

                i += skip;
            }
            while (j < t.Length && t[^j] == '#')
            {
                skip = 0;
                while (j < t.Length && (t[^j] == '#' || skip != 0))
                {
                    skip += (t[^j] == '#' ? 1 : -1);
                    j++;
                }

                j += skip;
            }

            if (i >= s.Length && j >= t.Length)
            {
                if (i == s.Length && j == t.Length) return s[0] == t[0];
                if (i > s.Length && j == t.Length) return t[0] == '#';
                if(i == s.Length && j > t.Length) return s[0] == '#';
                return true;
            }
            if (i > s.Length || j > t.Length) return false;
            if (s[^i] != t[^j]) return false;
        }
    }
}
