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
        // No possible pairs (strictly increasing diagonal)
        yield return new object[] { new int[][] { [1,1],[2,2],[3,3] }, 0 };

        // Provided-like examples and basic cases
        yield return new object[] { new int[][] { [6,2],[4,4],[2,6] }, 2 };
        yield return new object[] { new int[][] { [3,1],[1,3],[1,1] }, 2 };
        yield return new object[] { new int[][] { [1,5],[2,0],[5,5] }, 2 };
        yield return new object[] { new int[][] { [3,2],[3,6] }, 1 };

        // Same-X degenerate rectangles allowed
        yield return new object[] { new int[][] { [1,5],[1,4],[1,3],[2,2] }, 3 };
        yield return new object[] { new int[][] { [3,5],[3,4] }, 1 };

        // Early break when we hit y == topY
        yield return new object[] { new int[][] { [1,5],[2,5],[3,1] }, 2 };

        // Interior point prevents counting further for the same top (strictly increasing y chain)
        yield return new object[] { new int[][] { [1,5],[2,4],[3,4] }, 2 };

        // Negative coordinates supported
        yield return new object[] { new int[][] { [-2,5],[0,3],[1,4] }, 2 };

        // Mixed spread with ties
        yield return new object[] { new int[][] { [0,0],[1,0],[2,-1] }, 2 };
    }
}
