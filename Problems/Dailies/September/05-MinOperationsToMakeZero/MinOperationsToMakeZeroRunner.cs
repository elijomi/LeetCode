namespace LeetCodeProblems.Dailies.MinOperationsToMakeZero;

/// <summary>
/// https://leetcode.com/problems/minimum-operations-to-make-the-integer-zero
/// </summary>
public static class Runner
{
    public static void Run()
    {
        var solver = new Solution();

        // Test cases
        var tests = new (int num1, int num2, int expected)[]
        {
            (3, -2, 3),
            (5, 7, -1),
            (112577768, -501662198, 16)
        };

        int i = 1;
        foreach (var (num1, num2, expected) in tests)
        {
            var actual = solver.MakeTheIntegerZero(num1, num2);
            Console.WriteLine($"Test {i}: expected={expected}, actual={actual} - {(actual == expected ? "PASS" : "FAIL")}");
            i++;
        }
    }
}
