namespace LeetCodeProblems.Dailies.SumOfTwoNoZeroInts;

/// <summary>
/// Given an integer n, return a list of two integers [a, b] where:
/// a and b are No-Zero integers.
/// a + b = n
/// 
/// Constraints:
/// 2 <= n <= 10^4
/// </summary>
public class Solution
{
    private static bool HasZero(int number)
    {
        if (number == 0) return true;

        int n = Math.Abs(number);
        while (n > 0)
        {
            if (n % 10 == 0) return true;
            n /= 10;
        }

        return false;
    }

    public int[] GetNoZeroIntegers(int n)
    {
        for (int i = 1; i < n; i++)
        {
            if (!HasZero(i) && !HasZero(n - i)) return [i, n - i];
        }

        throw new ArgumentException("No-zero solution not possible with given arguments!");
    }
}