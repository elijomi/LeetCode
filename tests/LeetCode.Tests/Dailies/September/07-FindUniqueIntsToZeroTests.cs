using LeetCode.Dailies.FindUniqueIntsToZero;
using Xunit;

namespace LeetCode.Tests.Dailies.September;

public class FindUniqueIntsToZeroTests
{
    [Theory]
    [InlineData(5)]
    [InlineData(3)]
    [InlineData(1)]
    public void SumZero_ProducesNUniqueIntegersSummingToZero(int n)
    {
        var solver = new FindUniqueIntsToZeroSolution();
        var res = solver.SumZero(n);

        Assert.Equal(n, res.Length);
        Assert.Equal(0, res.Sum());
        Assert.Equal(n, new HashSet<int>(res).Count);
    }
}

