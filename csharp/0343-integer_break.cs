namespace IntegerBreak
{
    public class Solution
    {
        public int IntegerBreak(int n)
        {
            if (n == 0b11)
                return n - 1;
            var r = 1;
            while (n > 0b1010)
            {
                r *= 0b11;
                n -= 0b11;
            }
            r = Rec(n, r);
            return r;
        }

        public int Rec(int n, int total)
        {
            if (n < 0)
                return -1;
            if (n == 0)
                return total;
            return Math.Max(Rec(n - 0b10, total * 0b10), Rec(n - 0b11, total * 0b11));
        }
    }
}
