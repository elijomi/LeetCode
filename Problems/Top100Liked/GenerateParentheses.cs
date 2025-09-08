namespace LeetCodeProblems.Top100Liked.GenerateParentheses;

/// <summary>
/// https://leetcode.com/problems/generate-parentheses
/// </summary>
public class Runner
{
    public static void Run()
    {
        var solver = new Solution();

        // Test cases
        var tests = new (int n, IList<string> expected)[]
        {
            (3, new List<string> { "((()))","(()())","(())()","()(())","()()()" }),
            (1, new List<string> { "()" }),
            (2, new List<string> { "(())", "()()" }),
            (4, new List<string> { "(((())))","((()()))","((())())","((()))()","(()(()))","(()()())","(()())()","(())(())","(())()()","()((()))","()(()())","()(())()","()()(())","()()()()" }),
            (0, new List<string> { "" })
        };

        int i = 1;
        foreach (var (n, expected) in tests)
        {
            var actual = solver.GenerateParenthesis(n);
            Console.WriteLine($"Test {i}: expected=[{string.Join(",", expected)}], actual=[{string.Join(",", actual)}] - {(actual.SequenceEqual(expected) ? "PASS" : "FAIL")}");
            i++;
        }
    }
}

/// <summary>
/// Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.
/// 
/// Constraints:
/// 1 <= n <= 8
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