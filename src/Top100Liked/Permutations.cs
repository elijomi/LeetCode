namespace LeetCode.Top100Liked.Permutations;

/// <summary>
/// Given an array nums of distinct integers, return all the possible permutations. You can return the answer in any order.
/// 
/// https://leetcode.com/problems/permutations
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
