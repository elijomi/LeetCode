using LeetCode.Dailies.MinOperationsToMakeZero;
using Xunit;

namespace LeetCode.Tests.Dailies.September;

public class MinOperationsToMakeZeroTests
{
    [Theory]
    // Examples provided by LeetCode
    [InlineData(3, -2, 3)]                 // from existing tests
    [InlineData(5, 7, -1)]                 // impossible when num2 positive and too large
    [InlineData(112577768, -501662198, 16)]

    // Base and boundary behaviors
    [InlineData(0, 5, 0)]                  // already zero
    [InlineData(1, 1, -1)]                 // num2 > 0 and num1 < num2 + 1 => impossible
    [InlineData(2, 2, -1)]                 // triggers early k > t guard

    // Characteristic scenarios
    [InlineData(13, 0, 3)]                 // num2 = 0 -> answer is popcount(num1) = 3
    [InlineData(3, 1, 1)]                  // single op: 3 = (2^1 + 1)
    [InlineData(10, 3, 2)]                 // 10 + 2*3 = 16 = 2^1 + 2^1 + 2^2 (sum of two powers with repetition)
    public void MakeTheIntegerZero_ReturnsExpected(int num1, int num2, int expected)
    {
        var solver = new MinOperationsToMakeZeroSolution();
        var actual = solver.MakeTheIntegerZero(num1, num2);
        Assert.Equal(expected, actual);
    }
}
