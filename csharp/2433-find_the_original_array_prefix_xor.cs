namespace csharp;

public class _2433_find_the_original_array_prefix_xor {
    public int[] FindArray(int[] pref)
    {
        if (pref == null || pref.Length <= 1)
        {
            return pref;
        }
        var cur = pref[0];
        for (var i = 1; i < pref.Length; i++)
        {
            pref[i] = cur ^ pref[i];
            cur = pref[i] ^ cur;
        }

        return pref;
    }
}