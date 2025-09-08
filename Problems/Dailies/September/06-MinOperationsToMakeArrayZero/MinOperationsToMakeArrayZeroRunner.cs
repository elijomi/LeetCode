namespace LeetCodeProblems.Dailies.MinOperationsToMakeArrayZero;

/// <summary>
/// https://leetcode.com/problems/minimum-operations-to-make-array-elements-zero
/// </summary>
public static class Runner
{
    public static void Run()
    {
        var solver = new Solution();

        // Test cases
        var tests = new (int[][] queries, int expected)[]
        {
            (new int[][] { [1,2],[2,4] }, 3),
            (new int[][] { [2,6] }, 4),
            (new int[][] { [3,10] }, 8),
            (new int[][] { [24,25] }, 3),
        };

        int i = 1;
        foreach (var (queries, expected) in tests)
        {
            var actual = solver.MinOperations(queries);
            Console.WriteLine($"Test {i}: expected={expected}, actual={actual} - {(actual == expected ? "PASS" : "FAIL")}");
            i++;
        }
    }
}
