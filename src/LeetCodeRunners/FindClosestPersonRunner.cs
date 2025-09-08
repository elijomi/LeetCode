using LeetCodeProblems.Dailies.FindClosestPerson;

namespace LeetCodeRunners.FindClosestPerson;

/// <summary>
/// Runner class for the Find Closest Person problem as specified by
/// Leetcode Daily Sep 4th 2025 (https://leetcode.com/problems/find-closest-person)
/// </summary>
public static class FindClosestPersonRunner
{
    public static void Run()
    {
        var solver = new FindClosestPersonSolver();

        // Test cases
        var tests = new (int x, int y, int z, int expected)[]
        {
            (2, 7, 4, 1),
            (2, 5, 6, 2),
            (1, 5, 3, 0)
        };

        int i = 1;
        foreach (var (x, y, z, expected) in tests)
        {
            var actual = solver.FindClosest(x, y, z);
            Console.WriteLine($"Test {i}: expected={expected}, actual={actual} - {(actual == expected ? "PASS" : "FAIL")}");
            i++;
        }
    }
}
