namespace csharp;

public class _1220_count_vowels_permutation
{
    private enum Vowel{
        A,
        E,
        I,
        O,
        U
    }

    public int CountVowelPermutation(int n) {
        const int MOD = 1000000007;
        var aeiou = new long[]{1,1,1,1,1};
        var tmp = new long[5];
        for (var i = 1; i < n; i++) {
            tmp[(int)Vowel.A] = (aeiou[(int)Vowel.U] + aeiou[(int)Vowel.I] + aeiou[(int)Vowel.E]) % MOD;
            tmp[(int)Vowel.E] = (aeiou[(int)Vowel.I] + aeiou[(int)Vowel.A]) % MOD;
            tmp[(int)Vowel.I] = (aeiou[(int)Vowel.O] + aeiou[(int)Vowel.E]) % MOD;
            tmp[(int)Vowel.O] = (aeiou[(int)Vowel.I]) % MOD;
            tmp[(int)Vowel.U] = (aeiou[(int)Vowel.O] + aeiou[(int)Vowel.I]) % MOD;
            for(var j = 0; j < 5; j++)
            {
                aeiou[j] = tmp[j];
            }
        }
        return (int) aeiou.Aggregate((x, y) => (x + y) % MOD);
    }
}
