namespace LeetCode.Dailies.FindUniqueIntsToZero;

/// <summary>
/// Given an integer n, return any array containing n unique integers such that they add up to 0.
/// 
/// https://leetcode.com/problems/find-n-unique-integers-sum-up-to-zero
/// </summary>
public class FindUniqueIntsToZeroSolution
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