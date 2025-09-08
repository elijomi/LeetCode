using LeetCode.Dailies.MaxAveragePassRatio;
using Xunit;

namespace LeetCode.Tests.Dailies.September;

public class MaxAveragePassRatioTests
{
    [Fact]
    public void MaxAverageRatio_MatchesExpectedWithinTolerance()
    {
        var solver = new MaxAveragePassRatioSolver();
        int[][] classes = [ [1, 2], [3, 5], [2, 2] ];
        int extraStudents = 2;
        double expected = 0.7833333333333333;

        var actual = solver.MaxAverageRatio(classes, extraStudents);
        Assert.Equal(expected, actual, 10);
    }
}

