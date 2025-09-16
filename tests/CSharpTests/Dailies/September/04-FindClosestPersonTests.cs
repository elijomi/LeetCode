using LeetCode.Dailies.FindClosestPerson;
using Xunit;

namespace LeetCode.Tests.Dailies.September;

public class FindClosestPersonTests
{
    [Theory]
    // Examples provided by LeetCode
    [InlineData(2, 7, 4, 1)]    // Person 1 closer
    [InlineData(2, 5, 6, 2)]    // Person 2 closer
    [InlineData(1, 5, 3, 0)]    // Tie

    // Edge/Boundary style cases within 1..100
    [InlineData(4, 10, 4, 1)]   // x already at z
    [InlineData(8, 3, 3, 2)]    // y already at z
    [InlineData(7, 3, 5, 0)]    // equal distance to z from both sides
    [InlineData(5, 6, 1, 1)]    // x closer
    [InlineData(99, 1, 50, 0)]  // large spread tie
    [InlineData(1, 100, 1, 1)]  // x at z, y far
    [InlineData(100, 1, 100, 1)]// y far, x at z
    public void FindClosest_ReturnsExpected(int x, int y, int z, int expected)
    {
        var solver = new FindClosestPersonSolver();
        var actual = solver.FindClosest(x, y, z);
        Assert.Equal(expected, actual);
    }
}
