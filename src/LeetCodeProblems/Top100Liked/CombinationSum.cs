namespace LeetCodeProblems.Top100Liked.CombinationSum;

public static class Runner
{
    /// <summary>
    /// https://leetcode.com/problems/combination-sum/description
    /// </summary>
    public static void Run()
    {
        var solver = new Solution();

        // Test cases
        var tests = new (int[] candidates, int target, IList<IList<int>> expected)[]
        {
            (new int[] {2,3,6,7}, 7, new List<IList<int>> { new List<int> {7}, new List<int> {2,2,3} }),
            (new int[] {2,3,5}, 8, new List<IList<int>> { new List<int> {2,2,2,2}, new List<int> {2,3,3}, new List<int> {3,5} }),
            (new int[] {2}, 1, new List<IList<int>> { }),
            (new int[] {1}, 1, new List<IList<int>> { new List<int> {1} }),
            (new int[] {1}, 2, new List<IList<int>> { new List<int> {1,1} })
        };

        int i = 1;
        foreach (var (candidates, target, expected) in tests)
        {
            var actual = solver.CombinationSum(candidates, target);
            Console.WriteLine($"Test {i}: expected=[{string.Join(" | ",
            expected.Select(e => "[" + string.Join(",", e) + "]"))}], actual=[{string.Join(" | ",
            actual.Select(a => "[" + string.Join(",", a) + "]"))}] - {(IsEqual(actual, expected) ? "PASS" : "FAIL")}");
            i++;
        }
    }

    private static bool IsEqual(IList<IList<int>> a, IList<IList<int>> b)
    {
        if (a.Count != b.Count) return false;

        var setA = new HashSet<string>(a.Select(x => string.Join(",", x.OrderBy(n => n))));
        var setB = new HashSet<string>(b.Select(x => string.Join(",", x.OrderBy(n => n))));

        return setA.SetEquals(setB);
    }
}

/// <summary>
/// Given an array of distinct integers candidates and a target integer target, return a list of all unique combinations 
/// of candidates where the chosen numbers sum to target. You may return the combinations in any order.
/// 
/// The same number may be chosen from candidates an unlimited number of times. Two combinations are unique if the 
/// frequency of at least one of the chosen numbers is different.
/// 
/// The test cases are generated such that the number of unique combinations that sum up to target is less than 150 
/// combinations for the given input.
/// 
/// Constraints:
/// 1 <= candidates.length <= 30
/// 2 <= candidates[i] <= 40
/// All elements of candidates are distinct.
/// 1 <= target <= 40
/// </summary>
public class Solution
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        var res = new List<IList<int>>();
        CombinationSumRecusively(candidates, target, new List<int>(), 0, res);
        return res;
    }

    private void CombinationSumRecusively(int[] candidates, int target, List<int> current, int startIndex, IList<IList<int>> res)
    {
        if (target == 0)
        {
            res.Add(new List<int>(current));
            return;
        }

        for (int i = startIndex; i < candidates.Length; i++)    // not i = 0, because we don't want to reuse previous elements, we want to reuse current element though
        {
            int element = candidates[i];
            if (element > target) continue;

            current.Add(element);
            CombinationSumRecusively(candidates, target - element, current, i, res);
            current.RemoveAt(current.Count - 1);
        }
    }
}