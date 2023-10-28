namespace csharp;

public class _0342_power_of_four {
    public bool IsPowerOfFour(int n)
    {
        if (n < 4) return n switch
        {
            1 => true,
            _ => false
        };
        while (n > 4 && n % 4 == 0)
        {
            n /= 4;
        }

        return n == 4 || n == 0;
    }

    public bool IsPowerOfFourMath(int n)
    {
        if (n <= 4) return n switch
        {
            1 => true,
            _ => false
        };
        return Math.Log(n, 4) % 1 == 0;
    }

    public bool IsPowerOfFourBitManip(int n)
    {
        return n > 0 && (n & (n - 1)) == 0 && (n & 0x55555555) == n;
    }
}