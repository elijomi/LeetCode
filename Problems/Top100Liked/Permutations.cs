using System.Runtime.CompilerServices;

namespace LeetCodeProblems.Top100Liked.Permutations;

/// <summary>
/// https://leetcode.com/problems/permutations
/// </summary>
public static class Runner
{
    /// <summary>
    /// 
    /// </summary>
    public static void Run()
    {
        var solver = new Solution();

        // Test cases
        var tests = new (int[] nums, IList<IList<int>> expected)[]
        {
            (new int[] {1,2,3}, new List<IList<int>> {
                new List<int> {1,2,3},
                new List<int> {1,3,2},
                new List<int> {2,1,3},
                new List<int> {2,3,1},
                new List<int> {3,1,2},
                new List<int> {3,2,1}
            }),
            (new int[] {0,1}, new List<IList<int>> {
                new List<int> {0,1},
                new List<int> {1,0}
            }),
            (new int[] {1}, new List<IList<int>> {
                new List<int> {1}
            })
        };

        int i = 1;
        foreach (var (nums, expected) in tests)
        {
            var actual = solver.Permute(nums);
            Console.WriteLine($"Test {i}: expected=[{string.Join(" | ", expected.Select(e => $"[{string.Join(",", e)}]"))}], actual=[{string.Join(" | ", actual.Select(a => $"[{string.Join(",", a)}]"))}] - {(actual.Count == expected.Count && actual.All(a => expected.Any(e => e.SequenceEqual(a))) ? "PASS" : "FAIL")}");
            i++;
        }
    }
}

/// <summary>
/// Given an array nums of distinct integers, return all the possible permutations. You can return the answer in any order.
/// </summary>
public class Solution
{
    public IList<IList<int>> Permute(int[] nums)
    {
        var res = new List<IList<int>>();
        PermuteRecursively(nums, 0, res);
        return res;
    }

    private void PermuteRecursively(int[] nums, int startIndex, IList<IList<int>> result)
    {
         if (startIndex == nums.Length)
        {
            result.Add(new List<int>(nums));
            return;
        }

        for (int i = startIndex; i < nums.Length; i++)
        {
            (nums[startIndex], nums[i]) = (nums[i], nums[startIndex]);
            PermuteRecursively(nums, startIndex + 1, result);
            (nums[startIndex], nums[i]) = (nums[i], nums[startIndex]);
        }
    }
}