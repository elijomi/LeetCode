namespace LeetCode.Top100Liked.Subsets;

/// <summary>
/// Given an integer array nums of unique elements, return all possible subsets (the power set).
/// The solution set must not contain duplicate subsets.
/// 
/// Constraints:
/// 1 <= nums.length <= 10
/// -10 <= nums[i] <= 10
/// All the numbers of nums are unique.
/// 
/// https://leetcode.com/problems/subsets
/// </summary>
public class Solution
{
    public IList<IList<int>> Subsets(int[] nums)
    {
        var res = new List<IList<int>>
        {
            new List<int>(),   // [0]
        };

        for (int i = 1; i <= nums.Length; i++)
        {
            Combine(nums, i, 0, new List<int>(i), res);
        }

        return res;
    }

    private void Combine(int[] nums, int length, int start, List<int> subset, IList<IList<int>> res)
    {
        if (subset.Count == length)
        {
            res.Add(new List<int>(subset));
            return;
        }

        // ensure enough elements remain to fill k
        for (int i = start; i <= nums.Length - (length - subset.Count); i++)
        {
            subset.Add(nums[i]);
            Combine(nums, length, i + 1, subset, res);
            subset.RemoveAt(subset.Count - 1);
        }
    }
}
