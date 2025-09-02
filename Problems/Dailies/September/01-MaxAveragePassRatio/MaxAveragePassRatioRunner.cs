namespace LeetCodeProblems.Dailies.MaxAveragePassRatio;

/// <summary>
/// Runner class for the Max Average Pass Ratio problem as specified by
/// Leetcode Daily Sep 1st 2025 (https://leetcode.com/problems/maximum-average-pass-ratio)
/// </summary>
public static class MaxAveragePassRatioRunner
{
    public static void Run()
    {
        var solver = new MaxAveragePassRatioSolver();
        
        // Test cases
        var tests = new (int[][] points, int extraStudents, double expected)[]
        {
            (new int[][] { [1, 2], [3, 5], [2, 2] }, 2, 0.7833333333333333 )
        };

        int i = 1;
        foreach (var (points, extraStudents, expected) in tests)
        {
            var actual = solver.MaxAverageRatio(points, extraStudents);
            Console.WriteLine($"Test {i}: expected={expected}, actual={actual} - {(actual == expected ? "PASS" : "FAIL")}");
            i++;
        }
    }
}