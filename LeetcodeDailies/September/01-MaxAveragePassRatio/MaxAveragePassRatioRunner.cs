namespace LeetCodeDailies.MaxAveragePassRatio;

/// <summary>
/// Runner class for the Max Average Pass Ratio problem as specified by
/// Leetcode Daily Sep 1st 2025 (https://leetcode.com/problems/maximum-average-pass-ratio)
/// </summary>
public static class MaxAveragePassRatioRunner
{
    public static void Run()
    {
        var solver = new MaxAveragePassRatioSolver();
        var result = solver.MaxAverageRatio(new int[][] { [1, 2], [3, 5], [2, 2] }, 2);
        Console.WriteLine(result);
    }
}