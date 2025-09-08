using LeetCode.Dailies.FindUniqueIntsToZero;
using Xunit;

namespace LeetCode.Tests.Dailies.September;

public class FindUniqueIntsToZeroTests
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(11)]
    public void SumZero_ReturnsNUniqueIntegersSummingToZero(int n)
    {
        var solver = new FindUniqueIntsToZeroSolution();
        var res = solver.SumZero(n);

        // length and uniqueness
        Assert.Equal(n, res.Length);
        Assert.Equal(n, new HashSet<int>(res).Count);

        // sum is zero
        Assert.Equal(0, res.Sum());
    }

    [Fact]
    public void SumZero_ReturnsEmptyArray_WhenNIsZero()
    {
        var solver = new FindUniqueIntsToZeroSolution();
        var res = solver.SumZero(0);
        Assert.Empty(res);
    }
}
