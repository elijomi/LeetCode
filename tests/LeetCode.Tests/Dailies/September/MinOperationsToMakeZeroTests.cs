using LeetCode.Dailies.MinOperationsToMakeZero;
using Xunit;

namespace LeetCode.Tests.Dailies.September;

public class MinOperationsToMakeZeroTests
{
    [Theory]
    [InlineData(3, -2, 3)]
    [InlineData(5, 7, -1)]
    [InlineData(112577768, -501662198, 16)]
    public void MakeTheIntegerZero_ReturnsExpected(int num1, int num2, int expected)
    {
        var solver = new MinOperationsToMakeZeroSolution();
        var actual = solver.MakeTheIntegerZero(num1, num2);
        Assert.Equal(expected, actual);
    }
}

