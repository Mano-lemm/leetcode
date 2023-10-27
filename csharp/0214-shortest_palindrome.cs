namespace csharp;

public class _0214_shortest_palindrome
{
    /*
     *** implements Knuth-Morris-Pratt lookup table
     *** https://leetcode.com/problems/shortest-palindrome/Figures/214/shortest_palindrome.png
     *
     *** readup for this specific problem: https://leetcode.com/problems/shortest-palindrome/editorial/
     *** readup for Knuth-Morris-Pratt: https://en.wikipedia.org/wiki/Knuth%E2%80%93Morris%E2%80%93Pratt_algorithm
     */
    public string ShortestPalindrome(string s)
    {
        var rchar = s.ToCharArray();
        Array.Reverse(rchar);
        var reverse = new string(rchar);
        var s_new = s + '#' + reverse;
        var lookupTable = new int[s_new.Length];
        for (var i = 1; i < s_new.Length; i++)
        {
            var cur = lookupTable[i - 1];
            while (cur > 0 && s_new[i] != s_new[cur])
            {
                cur = lookupTable[cur - 1];
            }
            if (s_new[i] == s_new[cur])
            {
                cur++;
            }
            lookupTable[i] = cur;
        }

        return reverse.Substring(0, s.Length - lookupTable[s_new.Length - 1]) + s;
    }
}
