using LeetCode.Dailies.WaysToPlacePeople;
using Xunit;

namespace LeetCode.Tests.Dailies.September;

public class WaysToPlacePeopleTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void NumberOfPairs_ReturnsExpected(int[][] points, int expected)
    {
        var solver = new WaysToPlacePeopleSolver();
        var actual = solver.NumberOfPairs(points);
        Assert.Equal(expected, actual);
    }

    public static IEnumerable<object[]> TestData()
    {
        yield return new object[] { new int[][] { [1,1],[2,2],[3,3] }, 0 };
        yield return new object[] { new int[][] { [6,2],[4,4],[2,6] }, 2 };
        yield return new object[] { new int[][] { [3,1],[1,3],[1,1] }, 2 };
        yield return new object[] { new int[][] { [1,5],[2,0],[5,5] }, 2 };
        yield return new object[] { new int[][] { [3,2],[3,6] }, 1 };
    }
}

