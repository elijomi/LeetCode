namespace LeetCode.Top100Liked.GenerateParentheses;

/// <summary>
/// Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.
/// 
/// Constraints:
/// 1 <= n <= 8
/// 
/// https://leetcode.com/problems/generate-parentheses
/// </summary>
public class Solution
{
    public IList<string> GenerateParenthesis(int n)
    {
        var result = new List<string>();
        GenerateParenthesisRecursive(result, string.Empty, 0, 0, n);
        return result;
    }

    private void GenerateParenthesisRecursive(IList<string> result, string current, int open, int close, int max)
    {
        if (current.Length == max * 2)
        {
            result.Add(current);
            return;
        }

        if (open < max)
        {
            GenerateParenthesisRecursive(result, current + "(", open + 1, close, max);
        }
        if (close < open)
        {
            GenerateParenthesisRecursive(result, current + ")", open, close + 1, max);
        }
    }
}
