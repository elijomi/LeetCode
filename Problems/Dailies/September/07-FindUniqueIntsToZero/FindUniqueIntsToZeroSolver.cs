namespace LeetCodeProblems.Dailies.FindUniqueIntsToZero;

/// <summary>
/// Given an integer n, return any array containing n unique integers such that they add up to 0.
/// </summary>
public class Solution
{
    public int[] SumZero(int n)
    {
        var res = new int[n];
        for (int i = 0; i < n; i++)
        {
            res[i] = i * 2 - (n - 1);
        }
        
        return res;
    }
}