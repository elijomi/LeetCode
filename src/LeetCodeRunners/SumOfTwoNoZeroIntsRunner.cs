using LeetCodeProblems.Dailies.SumOfTwoNoZeroInts;

namespace LeetCodeRunners.SumOfTwoNoZeroInts;

/// <summary>
/// https://leetcode.com/problems/convert-integer-to-the-sum-of-two-no-zero-integers
/// </summary>
public static class Runner
{
    public static void Run()
    {
        var solver = new SumOfTwoNoZeroIntsSolution();

        var tests = new[] { 2, 11 };

        int i = 1;
        foreach (var n in tests)
        {
            int[] actual = solver.GetNoZeroIntegers(n);

            int sum = 0;
            for (int j = 0; j < actual.Length; j++)
            {
                sum += actual[j];
            }

            var actualDisplay = $"[" + string.Join(", ", actual) + "]";
            Console.WriteLine($"Test {i}: n={n}, sum={sum}, actual={actualDisplay} - {(sum == n ? "PASS" : "FAIL")}");
            i++;
        }
    }
}
