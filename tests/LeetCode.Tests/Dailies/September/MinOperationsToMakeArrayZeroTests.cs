using LeetCode.Dailies.MinOperationsToMakeArrayZero;
using Xunit;

namespace LeetCode.Tests.Dailies.September;

public class MinOperationsToMakeArrayZeroTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void MinOperations_ReturnsExpected(int[][] queries, long expected)
    {
        var solver = new MinOperationsToMakeArrayZeroSolution();
        var actual = solver.MinOperations(queries);
        Assert.Equal(expected, actual);
    }

    public static IEnumerable<object[]> TestData()
    {
        yield return new object[] { new int[][] { new[] { 1, 2 }, new[] { 2, 4 } }, 3L };
        yield return new object[] { new int[][] { new[] { 2, 6 } }, 4L };
        yield return new object[] { new int[][] { new[] { 3, 10 } }, 8L };
        yield return new object[] { new int[][] { new[] { 24, 25 } }, 3L };
    }
}

