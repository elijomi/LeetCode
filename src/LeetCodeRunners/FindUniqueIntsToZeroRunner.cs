using LeetCodeProblems.Dailies.FindUniqueIntsToZero;

namespace LeetCodeRunners.FindUniqueIntsToZero;

/// <summary>
/// https://leetcode.com/problems/find-n-unique-integers-sum-up-to-zero
/// </summary>
public static class Runner
{
    public static void Run()
    {
        var solver = new FindUniqueIntsToZeroSolution();

        var tests = new[] { 5, 3, 1 };

        int i = 1;
        foreach (var n in tests)
        {
            var actual = solver.SumZero(n);

            int sum = 0;
            for (int j = 0; j < actual.Length; j++)
            {
                sum += actual[j];
            }

            var actualDisplay = $"[" + string.Join(", ", actual) + "]";
            Console.WriteLine($"Test {i}: n={n}, sum={sum}, actual={actualDisplay} - {(sum == 0 ? "PASS" : "FAIL")}");
            i++;
        }
    }
}
