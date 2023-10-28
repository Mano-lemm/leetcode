using System.Text;

namespace csharp;

public class _0779_kth_symbol_in_grammar {
      public int KthGrammar(int n, int k)
      {
            while (true)
            {
                  if (n == 1) return 0;
                  var len = 1 << (n - 2);
                  if (k > len) return 1 - KthGrammar(n - 1, k - len);
                  n -= 1;
            }
      }
}