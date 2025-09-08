using LeetCode.Dailies.FindClosestPerson;
using Xunit;

namespace LeetCode.Tests.Dailies.September;

public class FindClosestPersonTests
{
    [Theory]
    [InlineData(2, 7, 4, 1)]
    [InlineData(2, 5, 6, 2)]
    [InlineData(1, 5, 3, 0)]
    public void FindClosest_ReturnsExpected(int x, int y, int z, int expected)
    {
        var solver = new FindClosestPersonSolver();
        var actual = solver.FindClosest(x, y, z);
        Assert.Equal(expected, actual);
    }
}

